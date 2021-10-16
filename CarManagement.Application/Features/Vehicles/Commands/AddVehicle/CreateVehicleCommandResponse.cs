using CarManagement.Application.Responses;
using FluentValidation.Results;

namespace CarManagement.Application.Features.Vehicles.Commands.AddVehicle
{
    public class CreateVehicleCommandResponse : BaseResponse
    {
        public int? VehicleId { get; set; }

        public CreateVehicleCommandResponse() : base()
        {
        }

        public CreateVehicleCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }

        public CreateVehicleCommandResponse(string message) : base(message)
        {
        }

        public CreateVehicleCommandResponse(string message, bool success) : base(message, success)
        {
        }

        public CreateVehicleCommandResponse(int vehicleId)
        {
            VehicleId = vehicleId;
        }
    }
}