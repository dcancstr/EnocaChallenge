using System;
using Enoca.Business.ViewModels.Carrier;
using FluentValidation;

namespace Enoca.Business.Validators.Carrier
{
	public class CreateCarrierValidator:AbstractValidator<CreateCarrierVM>
	{
		public CreateCarrierValidator()
		{
            RuleFor(cc => cc.CarrierName)
                .NotNull().NotEmpty().WithMessage("Kargo Firmasi adi boş gecilemez!");
            RuleFor(cc => cc.CarrierIsActive)
                .NotNull().WithMessage("Kargo firmasi aktiflik durumu boş gecilemez");
            RuleFor(cc => cc.CarrierPlusDesiCost)
                .NotNull().WithMessage("Kargo Firmasi desi ucreti boş gecilemez!")
                .GreaterThan(0).WithMessage("Kargo Firmasi desi ucreti 0 dan buyuk olmali!");
        }
	}
}

