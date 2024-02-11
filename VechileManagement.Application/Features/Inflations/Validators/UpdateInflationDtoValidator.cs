using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Inflations.DTOs;
using VechileManagement.Application.Features.VechileModel.DTOs;

namespace VechileManagement.Application.Features.Inflations.Validators
{
    public class UpdateInflationDtoValidator : AbstractValidator<UpdateInflationDto>
    {
        public UpdateInflationDtoValidator()
        {
            RuleFor(p => p.ServiceYear)
         .NotEmpty().WithMessage("{ServiceYear} is required.")
         .NotNull();

            RuleFor(p => p.Point)
        .NotEmpty().WithMessage("{Point} is required.")
        .NotNull();
        }
    }
}
