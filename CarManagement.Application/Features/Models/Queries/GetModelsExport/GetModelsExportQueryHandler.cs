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

namespace CarManagement.Application.Features.Models.Queries.GetModelsExport
{
    public class GetModelsExportQueryHandler : IRequestHandler<GetModelsExportQuery, ModelExportFileVm>
    {
        private readonly IAsyncRepository<Model> _modelRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetModelsExportQueryHandler(IMapper mapper, IAsyncRepository<Model> modelRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _modelRepository = modelRepository;
            _csvExporter = csvExporter;
        }

        public async Task<ModelExportFileVm> Handle(GetModelsExportQuery request, CancellationToken cancellationToken)
        {
            var allModels = _mapper.Map<List<ModelExportDto>>((await _modelRepository.GetAllAsync()));

            var fileData = _csvExporter.ExportModelsToCsv(allModels);

            var modelExportFileDto = new ModelExportFileVm() { ContentType = "text/csv", Data = fileData, ModelExportFileName = $"{Guid.NewGuid()}.csv" };

            return modelExportFileDto;
        }
    }
}