using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Countries.DTOs;
using VechileManagement.Application.Features.Depreciations.DTOs;

namespace VechileManagement.Application.Features.Depreciations.Validators
{
    public class CreateDeperciationDtoValidator : AbstractValidator<CreateDeperciationDto>
    {
        public CreateDeperciationDtoValidator() {
            RuleFor(p => p.Point)
.NotEmpty().WithMessage("{Point} is required.")
.NotNull().WithMessage("{Point} is required.");
            RuleFor(p => p.ServiceYear)
.NotEmpty().WithMessage("{ServiceYear} is required.")
.NotNull().WithMessage("{ServiceYear} is required.");
            RuleFor(p => p.VehicleServiceTypeId)
.NotEmpty().WithMessage("{VehicleServiceTypeId} is required.")
.NotNull().WithMessage("{VehicleServiceTypeId} is required.");

        }
    }
}
