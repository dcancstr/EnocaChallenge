using System;
using Enoca.Business.ViewModels.CarrierConfiguration;
using FluentValidation;

namespace Enoca.Business.Validators.CarrierConfiguration
{
	public class UpdateCarrierConfiguration: AbstractValidator<UpdateCarrierConfigurationVM>
    {
		public UpdateCarrierConfiguration()
		{
            RuleFor(uc => uc.Id).GreaterThan(0).WithMessage("Kargo Firmasi konfigurasyon id'si 0 dan buyuk olmali!");
            RuleFor(uc => uc.CarrierMaxDesi)
                .GreaterThan(0).WithMessage("Maksimum Desi 0 dan buyuk olmali!");
            RuleFor(uc => uc.CarrierMinDesi)
                .GreaterThan(0).WithMessage("Minimum Desi 0 dan buyuk olmali!");
            RuleFor(uc => uc.CarrierCost)
                .GreaterThan(0).WithMessage("Kargo Firmasi fiyati 0 dan buyuk olmali!");
            RuleFor(uc => uc.CarrierId)
                .GreaterThan(0).WithMessage("Kargo Firmasi id'si Desi 0 dan buyuk olmali!")
                .NotNull().WithMessage("Kargo Firmasi id'si bos gecilemez!");
        }
	}
}

