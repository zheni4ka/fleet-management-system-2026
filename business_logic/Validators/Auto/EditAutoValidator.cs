using business_logic.DTOs;
using FluentValidation;

namespace business_logic.Validators.Auto
{
    public class EditAutoValidator : AbstractValidator<EditAutoModel>
    {
        public EditAutoValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required").GreaterThan(0).WithMessage("Id must be greater than 0");

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
