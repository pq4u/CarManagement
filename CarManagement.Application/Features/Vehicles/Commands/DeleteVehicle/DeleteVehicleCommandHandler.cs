using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using MediatR;

namespace CarManagement.Application.Features.Vehicles.Commands.DeleteVehicle
{
    public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public DeleteVehicleCommandHandler(IMapper mapper, IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<Unit> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(request.VehicleId);
            await _vehicleRepository.DeleteAsync(vehicle);
            
            return Unit.Value;
        }
    }
}