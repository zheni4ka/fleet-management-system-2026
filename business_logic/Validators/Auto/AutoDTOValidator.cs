using business_logic.Entities;
using FluentValidation;

namespace business_logic.Validators
{
    public class AutoDTOValidator : AbstractValidator<business_logic.Entities.Auto>
    {
        public AutoDTOValidator() {
            RuleFor(x => x.Mark)
                .MaximumLength(16)
                .WithMessage("Name of this car must be less than 16");

            RuleFor(x => x.Mark)
                .NotEmpty()
                .WithMessage("Name of this car is required.");

             RuleFor(x => x.Model)
                .MaximumLength(16)
                .WithMessage("Model of this car must be less than 16");


        }
    }
}
