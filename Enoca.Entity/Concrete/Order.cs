﻿using System;
using Enoca.Core.Entities;

namespace Enoca.Entity.Concrete
{
    public class Order : BaseEntity<int>, IEntity
    {
        public int OrderDesi { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal OrderCarrierCost { get; set; }

        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }
    }
}

