using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using CarManagement.Application.Contracts.Infrastructure;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Vehicles.Queries.GetVehiclesExport
{
    public class GetVehiclesExportQueryHandler : IRequestHandler<GetVehiclesExportQuery, VehicleExportFileVm>
    {
        private readonly IAsyncRepository<Vehicle> _vehicleRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetVehiclesExportQueryHandler(IMapper mapper, IAsyncRepository<Vehicle> vehicleRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _csvExporter = csvExporter;
        }

        public async Task<VehicleExportFileVm> Handle(GetVehiclesExportQuery request, CancellationToken cancellationToken)
        {
            var allVehicles = _mapper.Map<List<VehicleExportDto>>((await _vehicleRepository.GetAllAsync()));

            var fileData = _csvExporter.ExportVehiclesToCsv(allVehicles);

            var vehicleExportFileDto = new VehicleExportFileVm() { ContentType = "text/csv", Data = fileData, VehicleExportFileName = $"{Guid.NewGuid()}.csv" };

            return vehicleExportFileDto;
        }
    }
}