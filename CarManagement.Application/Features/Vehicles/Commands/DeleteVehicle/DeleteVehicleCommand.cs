using MediatR;

namespace CarManagement.Application.Features.Vehicles.Commands.DeleteVehicle
{
    public class DeleteVehicleCommand : IRequest
    {
        public int VehicleId { get; set; }
    }
}