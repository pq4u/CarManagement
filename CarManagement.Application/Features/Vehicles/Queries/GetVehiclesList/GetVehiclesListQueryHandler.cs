using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Vehicles.Queries.GetVehiclesList
{
    public class GetVehiclesListQueryHandler : IRequestHandler<GetVehiclesListQuery, List<VehicleInListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Vehicle> _vehicleRepository;

        public GetVehiclesListQueryHandler(IMapper mapper, IAsyncRepository<Vehicle> vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }
        
        public async Task<List<VehicleInListViewModel>> Handle(GetVehiclesListQuery request, CancellationToken cancellationToken)
        {
            var all = await _vehicleRepository.GetAllAsync();

            return _mapper.Map<List<VehicleInListViewModel>>(all);
        }
    }
}