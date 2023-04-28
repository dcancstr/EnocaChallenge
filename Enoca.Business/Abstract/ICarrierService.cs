using System;
using Enoca.Business.ViewModels.Order;
using Enoca.Entity.Concrete;
using System.Linq.Expressions;
using Enoca.Business.ViewModels.Carrier;

namespace Enoca.Business.Abstract
{
	public interface ICarrierService
	{
        List<GetCarrierVM> GetAll(Expression<Func<Carrier, bool>> filter = null);
        string Add(CreateCarrierVM createCarrierVM);
        string Update(UpdateCarrierVM updateCarrierVM);
        string Delete(int id);
        GetCarrierVM Get(Expression<Func<Carrier, bool>> filter);
    }
}

