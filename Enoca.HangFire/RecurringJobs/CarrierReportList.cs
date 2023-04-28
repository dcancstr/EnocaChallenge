using System;
using Enoca.Business.Abstract;

namespace Enoca.HangFire.RecurringJobs
{
	public class CarrierReportList
	{
        private readonly IOrderService orderService;
        private readonly ICarrierReportService carrierReportService;

        public CarrierReportList(IOrderService orderService,ICarrierReportService carrierReportService)
		{
            this.orderService = orderService;
            this.carrierReportService = carrierReportService;
        }
        public async Task Manager()
        {
            var carrierReportList = await orderService.GetAllOrder();

            if (carrierReportList != null || carrierReportList.Count > 0)
            {
                await carrierReportService.CreateCarrierReportAsync(carrierReportList);   
            }
        }
	}
}

