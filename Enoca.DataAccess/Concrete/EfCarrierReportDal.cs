using System;
using Enoca.Core.DataAccess.EntityFramework;
using Enoca.DataAccess.Abstract;
using Enoca.Entity.Concrete;

namespace Enoca.DataAccess.Concrete
{
	public class EfCarrierReportDal:EfEntityRepositoryBase<CarrierReport, Context>,ICarrierReportDal
	{
		
	}
}

