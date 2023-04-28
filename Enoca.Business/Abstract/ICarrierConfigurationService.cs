using System;
using Enoca.Business.ViewModels.Carrier;
using Enoca.Entity.Concrete;
using System.Linq.Expressions;
using Enoca.Business.ViewModels.CarrierConfiguration;

namespace Enoca.Business.Abstract
{
	public interface ICarrierConfigurationService
	{
        List<GetCarrierConfigurationVM> GetAll(Expression<Func<CarrierConfiguration, bool>> filter = null);
        string Add(CreateCarrierConfigurationVM createCarrierConfigurationVM);
        string Update(UpdateCarrierConfigurationVM updateCarrierConfigurationVM);
        string Delete(int id);
        GetCarrierConfigurationVM Get(Expression<Func<CarrierConfiguration, bool>> filter);
    }
}

