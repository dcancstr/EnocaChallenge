using System;
using System.Linq.Expressions;
using AutoMapper;
using Enoca.Business.Abstract;
using Enoca.Business.ViewModels.Carrier;
using Enoca.Business.ViewModels.CarrierReport;
using Enoca.DataAccess.Abstract;
using Enoca.Entity.Concrete;

namespace Enoca.Business.Concrete
{
	public class CarrierReportManager:ICarrierReportService
	{
        private readonly ICarrierReportDal carrierReportDal;
        private readonly IMapper mapper;

        public CarrierReportManager(IMapper mapper, ICarrierReportDal carrierReportDal)
        {
            this.mapper = mapper;
            this.carrierReportDal = carrierReportDal;
        }
        public string Add(CreateCarrierReportVM createCarrierReportVM)
        {
            var carrierReport = mapper.Map<CarrierReport>(createCarrierReportVM);
            carrierReportDal.Add(carrierReport);
            return "Kargo Raporu basariyla eklendi";
        }

        public async Task CreateCarrierReportAsync(List<CreateCarrierReportVM> carrierReportList)
        {
            var carrierReport = mapper.Map<List<CarrierReport>>(carrierReportList);
            foreach (var item in carrierReport)
            {
                carrierReportDal.Add(item);
            }
        }
    }
}

