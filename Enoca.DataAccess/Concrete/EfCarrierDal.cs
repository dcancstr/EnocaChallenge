using System;
using Enoca.Core.DataAccess.EntityFramework;
using Enoca.DataAccess.Abstract;
using Enoca.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Enoca.DataAccess.Concrete
{
	public class EfCarrierDal:EfEntityRepositoryBase<Carrier,Context>,ICarrierDal
	{
		
	}
}

