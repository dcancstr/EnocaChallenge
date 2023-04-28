using System;
using Enoca.Business.ViewModels.Order;
using FluentValidation;

namespace Enoca.Business.Validators.Order
{
	public class CreateOrderValidator : AbstractValidator<CreateOrderVM>
    {
		public CreateOrderValidator()
		{
            RuleFor(co => co.OrderDesi)
                .GreaterThan(0).WithMessage("Siparis desisi 0 dan buyuk olmali!")
                .NotNull().WithMessage("Sipariş desi değeri bos gecilemez!");
        }
	}
}

