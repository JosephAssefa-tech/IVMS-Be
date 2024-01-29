using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.VechileModel.DTOs;

namespace VechileManagement.Application.Features.VechileModel.Validators
{
    public class UpdateVechileModelDtoValidator : AbstractValidator<UpdateVechileModelDto>
    {
        public UpdateVechileModelDtoValidator()
        {
            //RuleFor(p => p.)
            //    .NotEmpty().WithMessage("{EventName} is required.")
            //    .NotNull()
            //    .MaximumLength(50).WithMessage("{EventName} can not exceed more than 50 characters");
        }
    }
}
