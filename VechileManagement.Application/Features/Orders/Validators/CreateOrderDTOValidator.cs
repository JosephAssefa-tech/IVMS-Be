using VechileManagement.Application.Features.Orders.DTOs;
using FluentValidation;
using System;

namespace VechileManagement.Application.Features.Orders.Validators
{
    public class CreateOrderDTOValidator : AbstractValidator<CreateOrderDTO>
    {
        public CreateOrderDTOValidator()
        {
            RuleFor(p => p.OrderDate)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("{PropertyName} should be greate than today");
        }
    }
}
