using System;
using System.Linq.Expressions;
using AutoMapper;
using Enoca.Business.Abstract;
using Enoca.Business.ViewModels.Carrier;
using Enoca.DataAccess.Abstract;
using Enoca.Entity.Concrete;

namespace Enoca.Business.Concrete
{
	public class CarrierManager:ICarrierService
	{
        private readonly ICarrierDal carrierDal;
        private readonly IMapper mapper;

        public CarrierManager(ICarrierDal carrierDal,IMapper mapper)
		{
            this.carrierDal = carrierDal;
            this.mapper = mapper;
        }
        public string Add(CreateCarrierVM createCarrierVM)
        {
            var carrier = mapper.Map<Carrier>(createCarrierVM);
            carrierDal.Add(carrier);
            return "Kargo Firmasi basariyla eklendi";
        }
        public string Delete(int id)
        {
            var carrier = carrierDal.Get(f => f.Id == id);
            carrierDal.Delete(carrier);
            return "Kargo Firmasi basariyla silindi";
        }
        public GetCarrierVM Get(Expression<Func<Carrier, bool>> filter)
        {
            var carrier = carrierDal.Get(filter);
            var getCarrierVM = mapper.Map<GetCarrierVM>(carrier);
            return getCarrierVM;
        }
        public List<GetCarrierVM> GetAll(Expression<Func<Carrier, bool>> filter = null)
        {
            return carrierDal.GetAll(filter).Select(u => mapper.Map<GetCarrierVM>(u)).ToList();
        }
        public string Update(UpdateCarrierVM updateCarrierVM)
        {
            var carrier = carrierDal.Get(u => u.Id == updateCarrierVM.Id);
            carrier.Id = updateCarrierVM.Id;
            carrier.CarrierName = updateCarrierVM.CarrierName;
            carrier.CarrierIsActive = updateCarrierVM.CarrierIsActive;
            carrier.CarrierPlusDesiCost = updateCarrierVM.CarrierPlusDesiCost;
            carrierDal.Update(carrier);
            return "Kargo Firmasi guncellemesi basariyla yapildi";
        }
    }
}

