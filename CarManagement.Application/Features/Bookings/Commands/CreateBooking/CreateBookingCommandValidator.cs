using CarManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace CarManagement.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
    {
        public CreateBookingCommandValidator(IBookingRepository bookingRepository)
        {
            RuleFor(b => b.DateOut)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required")
                .LessThan(b => b.DateIn)
                .WithMessage("{PropertyName} must be less than date out");

            RuleFor(b => b.DateIn)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}