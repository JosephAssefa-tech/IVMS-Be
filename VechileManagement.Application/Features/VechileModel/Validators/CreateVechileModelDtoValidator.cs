using VechileManagement.Application.Features.VechileModel.DTOs;
using FluentValidation;


namespace VechileManagement.Application.Features.VechileModel.Validators
{
    public class CreateVechileModelDtoValidator : AbstractValidator<CreateVechileModelDto>
    {
        public CreateVechileModelDtoValidator()
        {
            RuleFor(dto => dto.Model)
                .NotEmpty().WithMessage("{Model} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{VechileModel} can not exceed more than 50 characters");
           
            RuleFor(p => p.Width)
               .NotEmpty().WithMessage("{Width} is required.")
               .NotNull();
            RuleFor(p => p.Length)
               .NotEmpty().WithMessage("{VechileLength} is required.")
               .NotNull();
            RuleFor(p => p.Height)
                .NotEmpty().WithMessage("{VechileHeight} is required.")
                .NotNull();


        }
    }
}
