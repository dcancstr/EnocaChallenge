using System;
namespace Enoca.Business.ViewModels.CarrierConfiguration
{
	public class UpdateCarrierConfigurationVM
	{
        public int Id { get; set; }
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public decimal CarrierCost { get; set; }

        public int CarrierId { get; set; }
    }
}

