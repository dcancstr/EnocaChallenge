using System;
using System.Linq.Expressions;
using AutoMapper;
using Enoca.Business.Abstract;
using Enoca.Business.ViewModels.Carrier;
using Enoca.Business.ViewModels.CarrierReport;
using Enoca.Business.ViewModels.Order;
using Enoca.DataAccess;
using Enoca.DataAccess.Abstract;
using Enoca.DataAccess.Concrete;
using Enoca.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Enoca.Business.Concrete
{
	public class OrderManager:IOrderService
	{
        private readonly IOrderDal orderDal;
        private readonly IMapper mapper;
        private readonly Context context;

        public OrderManager(IOrderDal orderDal,IMapper mapper,Context context)
		{
            this.orderDal = orderDal;
            this.mapper = mapper;
            this.context = context;
        }

        public string Add(CreateOrderVM createOrderVM)
        {
            var configControl =  context.CarrierConfigurations.Where(co => co.Carrier.CarrierIsActive).Any();
            if (!configControl) { return "Kargo Firmasi Konfigurasyonu  bulunamadi"; }
            var order = mapper.Map<Order>(createOrderVM);

            var config = context.CarrierConfigurations.Where(co => co.CarrierMinDesi <= createOrderVM.OrderDesi && co.CarrierMaxDesi >= createOrderVM.OrderDesi && co.Carrier.CarrierIsActive)
                .OrderBy(co => co.CarrierCost).FirstOrDefault();
            if (config != null)
            {
                order.CarrierId = config.CarrierId;
                order.OrderCarrierCost = config.CarrierCost;
            }
            else
            {
                var minDesi = context.CarrierConfigurations.Where(md => md.Carrier.CarrierIsActive).OrderBy(md => md.CarrierMinDesi).FirstOrDefault();
                if (createOrderVM.OrderDesi < minDesi.CarrierMinDesi)
                {
                    order.CarrierId = minDesi.CarrierId;
                    order.OrderCarrierCost = minDesi.CarrierCost;
                }
                else
                {
                    var maxDesi = context.CarrierConfigurations.Where(md => md.Carrier.CarrierIsActive).Include(md => md.Carrier).OrderByDescending(md => md.CarrierMaxDesi).FirstOrDefault();
                    order.CarrierId = maxDesi.CarrierId;
                    order.OrderCarrierCost = maxDesi.CarrierCost + ((order.OrderDesi - maxDesi.CarrierMaxDesi) * maxDesi.Carrier.CarrierPlusDesiCost);
                }

            }

            orderDal.Add(order);
            return "Siparis eklendi";
            
            
        }

        public string Delete(int id)
        {
            var order = orderDal.Get(f => f.Id == id);
            orderDal.Delete(order);
            return "Siparis basariyla silindi";
        }

        public GetOrderVM Get(Expression<Func<Order, bool>> filter)
        {
            var order = orderDal.Get(filter);
            var getOrderVM = mapper.Map<GetOrderVM>(order);
            return getOrderVM;
        }

        public List<GetOrderVM> GetAll(Expression<Func<Order, bool>> filter = null)
        {
            return orderDal.GetAll(filter).Select(u => mapper.Map<GetOrderVM>(u)).ToList();
        }
        public async Task<List<CreateCarrierReportVM>> GetAllOrder()
        {
           
            var reportList = context.Orders.GroupBy(o => new { o.CarrierId, o.OrderDate.Date })
                        .Select(g => new CreateCarrierReportVM
                        {
                            CarrierId = g.Key.CarrierId,
                            CarrierCost = g.Sum(o => o.OrderCarrierCost),
                            OrderDate = g.Key.Date
                        }).ToList();
            return reportList;
        }


    }
}

