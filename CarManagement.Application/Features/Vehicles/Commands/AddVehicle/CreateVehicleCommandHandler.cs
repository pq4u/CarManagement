using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Vehicles.Commands.AddVehicle
{
    public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, CreateVehicleCommandResponse>
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        public CreateVehicleCommandHandler(IMapper mapper, IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<CreateVehicleCommandResponse> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateVehicleCommandValidator(_vehicleRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new CreateVehicleCommandResponse(validatorResult);

            var vehicle = _mapper.Map<Vehicle>(request);
            vehicle = await _vehicleRepository.AddAsync(vehicle);

            return new CreateVehicleCommandResponse(vehicle.VehicleId);
        }
    }
}