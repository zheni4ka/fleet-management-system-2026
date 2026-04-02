using business_logic.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.Validators
{
    public class RouteValidator : AbstractValidator<Route>
    {
        public RouteValidator() 
        {
            RuleFor(x => x.Start)
                .NotEmpty()
                .WithMessage("Start point is required.")
                .MaximumLength(100)
                .WithMessage("Start point cannot exceed 100 characters.");

            RuleFor(x => x.Destination)
                .NotEmpty()
                .WithMessage("Destination is required.")
                .MaximumLength(100)
                .WithMessage("Destination cannot exceed 100 characters.");

             RuleFor(x => x.DriverId)
                .GreaterThan(0)
                .WithMessage("Driver ID must be greater than 0.");

             RuleFor(x => x.DepartureTime)
                .LessThan(x => x.ArrivalTime)
                .WithMessage("Departure time must be before arrival time.");

            RuleFor(x => x.ArrivalTime)
                .GreaterThan(x => x.DepartureTime)
                .WithMessage("Arrival time must be after departure time.");
        }
    }
}
