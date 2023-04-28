using System;
namespace Enoca.Business.ViewModels.Order
{
	public class UpdateOrderVM
	{
        public int Id { get; set; }
        public int OrderDesi { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderCarrierCost { get; set; }

        public int CarrierId { get; set; }
    }
}

