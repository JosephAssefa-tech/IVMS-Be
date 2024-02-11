using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Factories.DTOs;
using VechileManagement.Application.Features.VechileModel.DTOs;

namespace VechileManagement.Application.Features.Factories.Validators
{
    public class CreateFactoryDtoValidator : AbstractValidator<CreateFactoryDto>
    {
        public CreateFactoryDtoValidator()
        {
            RuleFor(dto => dto.FactoryNameAmh)
               .NotEmpty().WithMessage("{FactoryNameAmh} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{FactoryNameAmh} can not exceed more than 50 characters");
            RuleFor(dto => dto.FactoryNameEng)
           .NotEmpty().WithMessage("{FactoryNameEng} is required.")
           .NotNull()
           .MaximumLength(50).WithMessage("{FactoryNameEng} can not exceed more than 50 characters");

            RuleFor(p => p.Code)
                 .NotEmpty().WithMessage("{Code} is required.")
                 .NotNull();


        }
    }
}
