using business_logic.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.Validators
{
    public class AutoMaintenanceValidator : AbstractValidator<AutoMaintenance>
    {
        public AutoMaintenanceValidator() 
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
        }
    }
}
