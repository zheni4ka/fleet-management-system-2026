using business_logic.DTOs;
using FluentValidation;

namespace business_logic.Validators
{
    public class EditDriverModelValidator : AbstractValidator<EditDriverModel>
    {
        public EditDriverModelValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Matches(@"^[А-ЩЬЮЯҐЄІЇ][а-щьюяґєії]{0,16}$")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .Matches(@"^[А-ЩЬЮЯҐЄІЇ][а-щьюяґєії]{0,16}$")
                .MaximumLength(100).WithMessage("Surname cannot exceed 100 characters.");

            RuleFor(x => x.Patronymic)
                .NotEmpty().WithMessage("Patronymic is required.")
                .Matches(@"^[А-ЩЬЮЯҐЄІЇ][а-щьюяґєії]{0,16}$")
                .MaximumLength(100).WithMessage("Patronymic cannot exceed 100 characters.");

            RuleFor(x => x.LicenseNumber)
                .NotEmpty().WithMessage("Номер посвідчення водія є обов'я'зковим.")
                .Matches(@"^[A-Z]{3}\s\d{6}$")
                .WithMessage("Format must be correct (ABC 123456)");
        }
    }
}