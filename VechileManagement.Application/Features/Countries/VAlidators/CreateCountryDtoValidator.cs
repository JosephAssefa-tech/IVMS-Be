using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Countries.DTOs;
using VechileManagement.Application.Features.Customers.DTOs;

namespace VechileManagement.Application.Features.Countries.VAlidators
{
    public class CreateCountryDtoValidator : AbstractValidator<CreateCountryDto>
    {
        public CreateCountryDtoValidator()
        {
            RuleFor(p => p.CountryNameAmh)
                .NotEmpty().WithMessage("{CountryNameAmh} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{CountryNameAmh} can not exceed more than 50 characters");
            RuleFor(p => p.CountryNameEng)
                 .NotEmpty().WithMessage("{CountryNameEng} is required.")
                 .NotNull()
                 .MaximumLength(50).WithMessage("{CountryNameEng} can not exceed more than 50 characters");
            RuleFor(p => p.Point)
     .NotEmpty().WithMessage("{Point} is required.")
     .NotNull().WithMessage("{Point} is required.");

            RuleFor(p => p.CountryCode)
.NotEmpty().WithMessage("{CountryCode} is required.")
.NotNull().WithMessage("{CountryCode} is required.");

        }
    }
}
