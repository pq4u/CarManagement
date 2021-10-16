using CarManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace CarManagement.Application.Features.Colours.Commands.AddColour
{
    public class CreateColourCommandValidator : AbstractValidator<CreateColourCommand>
    {
        public CreateColourCommandValidator(IColourRepository colourRepository)
        {
            RuleFor(c => c.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            
            RuleFor(c => c.Code)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .MaximumLength(6);
        }
    }
}