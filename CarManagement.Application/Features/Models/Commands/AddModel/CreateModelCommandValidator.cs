using CarManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace CarManagement.Application.Features.Models.Commands.AddModel
{
    public class CreateModelCommandValidator : AbstractValidator<CreateModelCommand>
    {
        public CreateModelCommandValidator(IModelRepository modelRepository)
        {
            RuleFor(m => m.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}