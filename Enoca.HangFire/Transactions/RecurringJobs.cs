using System;
using Enoca.Entity.Concrete;
using Enoca.HangFire.RecurringJobs;
using Hangfire;

namespace Enoca.HangFire.Transactions
{
	public static class RecurringJobs
	{
        [Obsolete]
        public static void GetHourlyReport()
		{

            RecurringJob.RemoveIfExists(nameof(CarrierReportList));
            RecurringJob.AddOrUpdate<CarrierReportList>(nameof(CarrierReportList),
                job => job.Manager(), Cron.Hourly, TimeZoneInfo.Local);
        }

    }
}

