using System;
using Enoca.Core.Entities;

namespace Enoca.Entity.Concrete
{
    public class CarrierConfiguration : BaseEntity<int>, IEntity
    {
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public decimal CarrierCost { get; set; }

        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }
    }
}

