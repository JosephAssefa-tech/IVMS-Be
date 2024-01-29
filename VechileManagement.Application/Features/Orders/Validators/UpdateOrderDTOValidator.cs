using VechileManagement.Application.Features.Orders.DTOs;
using FluentValidation;
using System;


namespace VechileManagement.Application.Features.Orders.Validators
{
    public class UpdateOrderDTOValidator : AbstractValidator<UpdateOrderDTO>
    {
        public UpdateOrderDTOValidator()
        {
            RuleFor(p => p.OrderDate)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("{PropertyName} should be greate than today");
        }
    }
}
