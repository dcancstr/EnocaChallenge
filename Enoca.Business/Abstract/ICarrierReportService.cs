using System;
using Enoca.Business.ViewModels.Carrier;
using Enoca.Entity.Concrete;
using System.Linq.Expressions;
using Enoca.Business.ViewModels.CarrierReport;

namespace Enoca.Business.Abstract
{
	public interface ICarrierReportService
	{
        
        string Add(CreateCarrierReportVM createCarrierReportVM);
        Task CreateCarrierReportAsync(List<CreateCarrierReportVM> carrierReportList);

    }
}

