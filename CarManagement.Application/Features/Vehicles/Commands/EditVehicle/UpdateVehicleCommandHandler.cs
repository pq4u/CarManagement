using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Vehicles.Commands.EditVehicle
{
    public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository, IMapper mapper)
        {
            _vehicleRepository = vehicleRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehicle = _mapper.Map<Vehicle>(request);

            await _vehicleRepository.UpdateAsync(vehicle);
            return Unit.Value;
        }
    }
}