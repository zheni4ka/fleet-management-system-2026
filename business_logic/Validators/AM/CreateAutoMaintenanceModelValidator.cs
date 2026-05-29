using business_logic.DTOs;
using FluentValidation;

namespace business_logic.Validators
{
    public class CreateAutoMaintenanceModelValidator : AbstractValidator<CreateAutoMaintenanceModel>
    {
        public CreateAutoMaintenanceModelValidator()
        {
            RuleFor(x => x.AutoId)
                .GreaterThan(0)
                .WithMessage("Auto ID must be greater than 0.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Maintenance name is required.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Maintenance description is required.");

            RuleFor(x => x.ServiceDate)
                .LessThanOrEqualTo(System.DateTime.UtcNow)
                .WithMessage("Service date cannot be in the future.");
        }
    }
}
