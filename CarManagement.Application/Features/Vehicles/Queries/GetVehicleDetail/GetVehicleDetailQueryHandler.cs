using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Application.Features.Vehicles.Queries.GetVehicleDetail.Dtos;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Vehicles.Queries.GetVehicleDetail
{
    public class GetVehicleDetailQueryHandler : IRequestHandler<GetVehicleDetailQuery, VehicleDetailViewModel>
    {
        private readonly IAsyncRepository<Vehicle> _vehicleRepository;
        private readonly IAsyncRepository<Colour> _colourRepository;
        private readonly IAsyncRepository<Brand> _brandRepository;
        private readonly IAsyncRepository<Model> _modelRepository;
        private readonly IMapper _mapper;

        public GetVehicleDetailQueryHandler(IMapper mapper, IAsyncRepository<Vehicle> vehicleRepository, IAsyncRepository<Brand> brandRepository, IAsyncRepository<Colour> colourRepository, IAsyncRepository<Model> modelRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _brandRepository = brandRepository;
            _colourRepository = colourRepository;
            _modelRepository = modelRepository;
        }

        public async Task<VehicleDetailViewModel> Handle(GetVehicleDetailQuery request,
            CancellationToken cancellationToken)
        {
            var vehicle = await _vehicleRepository.GetByIdAsync(request.Id);
            
            var brand = await _brandRepository.GetByIdAsync(vehicle.BrandId);
            var colour = await _colourRepository.GetByIdAsync(vehicle.ColourId);
            var model = await _modelRepository.GetByIdAsync(vehicle.ModelId);
            
            var vehicleDetail = _mapper.Map<VehicleDetailViewModel>(vehicle);

            vehicleDetail.Brand = _mapper.Map<BrandDto>(brand);
            vehicleDetail.Colour = _mapper.Map<ColourDto>(colour);
            vehicleDetail.Model = _mapper.Map<ModelDto>(model);

            return vehicleDetail;
        }
    }
}