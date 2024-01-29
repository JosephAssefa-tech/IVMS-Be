using VechileManagement.Application.Features.Customers.DTOs;
using FluentValidation;

namespace VechileManagement.Application.Features.Customers.Validators
{
    public class CreateCustomerDTOValidator : AbstractValidator<CreateCustomerDTO>
    {
        public CreateCustomerDTOValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} can not exceed more than 50 characters");
        }
    }
}
