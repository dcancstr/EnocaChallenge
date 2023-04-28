using System;
using System.Linq.Expressions;
using AutoMapper;
using Enoca.Business.Abstract;
using Enoca.Business.ViewModels.Carrier;
using Enoca.Business.ViewModels.CarrierConfiguration;
using Enoca.DataAccess.Abstract;
using Enoca.DataAccess.Concrete;
using Enoca.Entity.Concrete;

namespace Enoca.Business.Concrete
{
	public class CarrierConfigurationManager:ICarrierConfigurationService
	{
        private readonly ICarrierConfigurationDal carrierConfigurationDal;
        private readonly IMapper mapper;

        public CarrierConfigurationManager(ICarrierConfigurationDal carrierConfigurationDal,IMapper mapper)
		{
            this.carrierConfigurationDal = carrierConfigurationDal;
            this.mapper = mapper;
        }

        public string Add(CreateCarrierConfigurationVM createCarrierConfigurationVM)
        {
            var carrierconf = mapper.Map<CarrierConfiguration>(createCarrierConfigurationVM);
            carrierConfigurationDal.Add(carrierconf);
            return "Kargo Firmasi Konfigurasyonu basariyla eklendi";
        }

        public string Delete(int id)
        {
            var carrierconf = carrierConfigurationDal.Get(f => f.Id == id);
            carrierConfigurationDal.Delete(carrierconf);
            return "Kargo Firmasi Konfigurasyonu basariyla silindi";
        }

        public GetCarrierConfigurationVM Get(Expression<Func<CarrierConfiguration, bool>> filter)
        {
            var carrierconf = carrierConfigurationDal.Get(filter);
            var getCarrierConfigurationVM = mapper.Map<GetCarrierConfigurationVM>(carrierconf);
            return getCarrierConfigurationVM;
        }

        public List<GetCarrierConfigurationVM> GetAll(Expression<Func<CarrierConfiguration, bool>> filter = null)
        {
            return carrierConfigurationDal.GetAll(filter).Select(u => mapper.Map<GetCarrierConfigurationVM>(u)).ToList();
        }

        public string Update(UpdateCarrierConfigurationVM updateCarrierConfigurationVM)
        {
            var carrierconf = carrierConfigurationDal.Get(u => u.Id == updateCarrierConfigurationVM.Id);
            carrierconf.Id = updateCarrierConfigurationVM.Id;
            carrierconf.CarrierMaxDesi = updateCarrierConfigurationVM.CarrierMaxDesi;
            carrierconf.CarrierMinDesi = updateCarrierConfigurationVM.CarrierMinDesi;
            carrierconf.CarrierCost = updateCarrierConfigurationVM.CarrierCost;
            carrierconf.CarrierId = updateCarrierConfigurationVM.CarrierId;
            carrierConfigurationDal.Update(carrierconf);
            return "Kargo Firmasi Konfigurasyonu guncellemesi basariyla yapildi";
        }
    }
}

