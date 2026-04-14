using business_logic.Entities;
using FluentValidation;
namespace business_logic.Validators
{
    public class DriverDTOValidator : AbstractValidator<Driver>
    {
        public DriverDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Matches(@"^[А-ЩЬЮЯҐЄІЇ][а-щьюяґєії]{0,16}$")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required.")
                .Matches(@"^[А-ЩЬЮЯҐЄІЇ][а-щьюяґєії]{0,16}$")
                .MaximumLength(100).WithMessage("Surname cannot exceed 100 characters.");

            RuleFor(x => x.Patronymic).NotEmpty().WithMessage("Patronymic is required.")
                .Matches(@"^[А-ЩЬЮЯҐЄІЇ][а-щьюяґєії]{0,16}$")
                .MaximumLength(100).WithMessage("Patronymic cannot exceed 100 characters.");

            RuleFor(x => x.LicenseNumber)
                .NotEmpty().WithMessage("Номер посвідчення водія є обов'язковим.")
                .Matches(@"^[A-Z]{3}\s\d{6}$")
                .WithMessage("Format must be correct (ABC 123456)");
        }
    }
}
