using business_logic.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.Validators
{
    public class AutoValidator : AbstractValidator<Auto>
    {
        public AutoValidator() {
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
