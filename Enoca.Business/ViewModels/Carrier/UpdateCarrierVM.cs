using System;
namespace Enoca.Business.ViewModels.Carrier
{
	public class UpdateCarrierVM
	{
        public int Id { get; set; }
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
    }
}

