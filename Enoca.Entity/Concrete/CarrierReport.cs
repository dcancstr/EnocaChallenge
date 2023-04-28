using System;
using Enoca.Core.Entities;

namespace Enoca.Entity.Concrete
{
    public class CarrierReport : BaseEntity<int>, IEntity
    {
        public decimal CarrierCost { get; set; }
        public DateTime CarrierReportDate { get; set; } = DateTime.Now;
        public DateTime OrderDate { get; set; }
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }
    }
}

