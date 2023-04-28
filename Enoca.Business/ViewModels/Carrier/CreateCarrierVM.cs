using System;
namespace Enoca.Business.ViewModels.Carrier
{
	public class CreateCarrierVM
	{
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
    }
}

