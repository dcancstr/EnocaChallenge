using System;
using Enoca.Core.DataAccess.EntityFramework;
using Enoca.DataAccess.Abstract;
using Enoca.Entity.Concrete;

namespace Enoca.DataAccess.Concrete
{
	public class EfOrderDal:EfEntityRepositoryBase<Order, Context>,IOrderDal
	{
		
	}
}

