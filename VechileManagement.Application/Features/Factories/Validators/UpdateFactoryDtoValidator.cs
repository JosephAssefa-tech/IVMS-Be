using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Factories.DTOs;
using VechileManagement.Application.Features.VechileModel.DTOs;

namespace VechileManagement.Application.Features.Factories.Validators
{
    public class UpdateFactoryDtoValidator : AbstractValidator<UpdateFactoryDto>
    {
        public UpdateFactoryDtoValidator()
        {
            //RuleFor(p => p.)
            //    .NotEmpty().WithMessage("{EventName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{EventName} can not exceed more than 50 characters");
        }
    }
}
