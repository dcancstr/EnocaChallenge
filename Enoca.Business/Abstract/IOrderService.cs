using System;
using System.Linq.Expressions;
using Enoca.Business.ViewModels.CarrierReport;
using Enoca.Business.ViewModels.Order;
using Enoca.Entity.Concrete;

namespace Enoca.Business.Abstract
{
	public interface IOrderService
	{
        List<GetOrderVM> GetAll(Expression<Func<Order, bool>> filter = null);
        string Add(CreateOrderVM createOrderVM);
        string Delete(int id);
        GetOrderVM Get(Expression<Func<Order, bool>> filter);
        Task<List<CreateCarrierReportVM>> GetAllOrder();
    }
}

