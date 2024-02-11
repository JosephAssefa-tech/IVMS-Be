using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Countries.DTOs;
using VechileManagement.Application.Features.VechileModel.DTOs;

namespace VechileManagement.Application.Features.Countries.VAlidators
{
    public class UpdateCounryDtoValidator : AbstractValidator<UpdateCountryDto>
    {
        public UpdateCounryDtoValidator()
        {
            //RuleFor(p => p.)
            //    .NotEmpty().WithMessage("{EventName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{EventName} can not exceed more than 50 characters");
        }
    }
}
