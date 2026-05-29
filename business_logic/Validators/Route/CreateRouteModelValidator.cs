using business_logic.DTOs;
using business_logic.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace business_logic.Validators
{
    public class CreateRouteModelValidator : AbstractValidator<CreateRouteModel>
    {
        public CreateRouteModelValidator() 
        {
            RuleFor(x => x.StartLocationId)
                .Cascade(CascadeMode.Stop)
                .Must(id => id == null || id > 0)
                .WithMessage("Start location id must be greater than 0 when provided.");

            RuleFor(x => x.DestinationLocationId)
                .Cascade(CascadeMode.Stop)
                .Must(id => id == null || id > 0)
                .WithMessage("Destination location id must be greater than 0 when provided.");

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
