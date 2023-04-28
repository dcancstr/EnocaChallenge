using System;
using Enoca.Business.ViewModels.CarrierConfiguration;
using FluentValidation;

namespace Enoca.Business.Validators.CarrierConfiguration
{
	public class CreateCarrierConfiguration :AbstractValidator<CreateCarrierConfigurationVM>
	{
		public CreateCarrierConfiguration()
		{
            RuleFor(cc => cc.CarrierMaxDesi)
                .GreaterThan(0).WithMessage("Maksimum Desi 0 dan buyuk olmali!");
            RuleFor(cc => cc.CarrierMinDesi)
                .GreaterThan(0).WithMessage("Minimum Desi 0 dan buyuk olmali!");
            RuleFor(cc => cc.CarrierCost)
                .GreaterThan(0).WithMessage("Kargo Firmasi fiyati 0 dan buyuk olmali!");
            RuleFor(cc => cc.CarrierId)
                .GreaterThan(0).WithMessage("Kargo Firmasi id'si 0 dan buyuk olmali!")
                .NotNull().WithMessage("Kargo Firmasi id'si bos gecilemez!");
        }
	}
}

