using CarManagement.Application.Contracts.Persistence;
using CarManagement.Application.Features.Bookings.Commands.CreateBooking;
using FluentValidation;

namespace CarManagement.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator(IBrandRepository brandRepository)
        {
            RuleFor(b => b.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}