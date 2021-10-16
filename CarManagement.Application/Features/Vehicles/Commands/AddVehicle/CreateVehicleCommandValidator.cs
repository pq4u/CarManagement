using CarManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace CarManagement.Application.Features.Vehicles.Commands.AddVehicle
{
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator(IVehicleRepository vehicleRepository)
        {
            RuleFor(v => v.Year)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            
            RuleFor(v => v.Brand)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            
            RuleFor(v => v.Colour)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            
            RuleFor(v => v.Model)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            
            RuleFor(v => v.LicensePlateNumber)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
            
            RuleFor(v => v.RentalRate)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} is required");
        }
    }
}