using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.DTOs;

namespace VechileManagement.Application.Features.FactoryServiceTypeParameters.Validators
{
    public class UpdateFactoryServiceTypeParameterDtoValidator : AbstractValidator<UpdateFactoryServiceTypeParameterDto>
    {
        public UpdateFactoryServiceTypeParameterDtoValidator()
        {

            RuleFor(p => p.FactoryId)
                    .NotEmpty().WithMessage("{FactoryId} is required.")
                    .NotNull();

            RuleFor(p => p.VehicleServiceTypeId)
           .NotEmpty().WithMessage("{VehicleServiceTypeId} is required.")
           .NotNull();
        }
    }
}
