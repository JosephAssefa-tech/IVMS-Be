using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.DTOs;
using VechileManagement.Application.Features.Inflations.DTOs;

namespace VechileManagement.Application.Features.FactoryServiceTypeParameters.Validators
{
    public class CreateFactoryServiceTypeParameterDtoValidator : AbstractValidator<CreateFactoryServiceTypeParameterDto>
    {
        public CreateFactoryServiceTypeParameterDtoValidator()
        {
            RuleFor(p => p.VehicleServiceTypeId)
           .NotEmpty().WithMessage("{VehicleServiceTypeId} is required.")
           .NotNull();

            RuleFor(p => p.FactoryId)
        .NotEmpty().WithMessage("{FactoryId} is required.")
        .NotNull();

            RuleFor(p => p.Point)
       .NotEmpty().WithMessage("{Point} is required.")
       .NotNull();
        }
    }
}
