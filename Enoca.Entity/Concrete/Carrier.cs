using System;
using Enoca.Core.Entities;

namespace Enoca.Entity.Concrete
{
    public class Carrier : BaseEntity<int>, IEntity
    {
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }

        public IEnumerable<CarrierConfiguration> CarrierConfigurations { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<CarrierReport> CarrierReports { get; set; }

    }
}

