using business_logic.Entities;
using FluentValidation;

namespace business_logic.Validators
{
    public class AutoDTOValidator : AbstractValidator<business_logic.Entities.Auto>
    {
        public AutoDTOValidator() {
            RuleFor(x => x.Name)
                .MinimumLength(16)
                .WithMessage("Name of this car must be less than 16");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name of this car is required.");

             RuleFor(x => x.Model)
                .MinimumLength(16)
                .WithMessage("Model of this car must be less than 16");
        }
    }
}
