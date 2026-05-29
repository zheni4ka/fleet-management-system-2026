using business_logic.DTOs;
using FluentValidation;

namespace business_logic.Validators.Auto
{
    public class CreateAutoValidator : AbstractValidator<CreateAutoModel>
    {
        public CreateAutoValidator()
        {
            RuleFor(x => x.Mark)
                .MaximumLength(16)
                .WithMessage("Name of this car must be less than 16");

            RuleFor(x => x.Mark)
                .NotEmpty()
                .WithMessage("Name of this car is required.");

            RuleFor(x => x.Model)
               .MaximumLength(16)
               .WithMessage("Model of this car must be less than 16");

            RuleFor(x => x.Number)
                .Matches((@"^[А-ЩЬЮЯҐЄІЇ][А-ЩЬЮЯҐЄІЇ][0-9]{0,4}[А-ЩЬЮЯҐЄІЇ][А-ЩЬЮЯҐЄІЇ]$"));
        }
    }
}
