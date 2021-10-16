using CarManagement.Application.Contracts.Persistence;
using CarManagement.Application.Features.Bookings.Commands.CreateBooking;
using FluentValidation;

namespace CarManagement.Application.Features.Customers.Commands.AddCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator(ICustomerRepository customerRepository)
        {
            RuleFor(c => c.FirstName)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");

            RuleFor(c => c.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            
            RuleFor(c => c.Street)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            
            RuleFor(c => c.ZipCode)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            
            RuleFor(c => c.City)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            
            RuleFor(c => c.ContactNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            
            RuleFor(c => c.EmailAddress)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            
        }
    }
}