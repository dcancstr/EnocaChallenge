using System;
using Enoca.Business.ViewModels.Carrier;
using FluentValidation;

namespace Enoca.Business.Validators.Carrier
{
	public class UpdateCarrierValidator:AbstractValidator<UpdateCarrierVM>
	{
		public UpdateCarrierValidator()
		{
            RuleFor(uc => uc.Id).GreaterThan(0).WithMessage("Kargo Firmasi id'si 0 dan buyuk olmali!");
            RuleFor(uc => uc.CarrierName)
               .NotNull().NotEmpty().WithMessage("Kargo Firmasi adi bos gecilemez!");
            RuleFor(uc => uc.CarrierIsActive)
                .NotNull().WithMessage("Kargo Firmasi aktiflik durumu bos gecilemez!");
            RuleFor(uc => uc.CarrierPlusDesiCost)
                .NotNull().WithMessage("Kargo Firmasi desi ücreti bos gecilemez!")
                .GreaterThan(0).WithMessage("Kargo Firmasi desi ucreti 0 dan buyuk olmali!");
        }
	}
}

