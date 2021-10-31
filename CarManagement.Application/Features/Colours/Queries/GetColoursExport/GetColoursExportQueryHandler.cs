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

namespace CarManagement.Application.Features.Colours.Queries.GetColoursExport
{
    public class GetColoursExportQueryHandler : IRequestHandler<GetColoursExportQuery, ColourExportFileVm>
    {
        private readonly IAsyncRepository<Colour> _colourRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetColoursExportQueryHandler(IMapper mapper, IAsyncRepository<Colour> colourRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _colourRepository = colourRepository;
            _csvExporter = csvExporter;
        }

        public async Task<ColourExportFileVm> Handle(GetColoursExportQuery request, CancellationToken cancellationToken)
        {
            var allColours = _mapper.Map<List<ColourExportDto>>((await _colourRepository.GetAllAsync()));

            var fileData = _csvExporter.ExportColoursToCsv(allColours);

            var colourExportFileDto = new ColourExportFileVm() { ContentType = "text/csv", Data = fileData, ColourExportFileName = $"{Guid.NewGuid()}.csv" };

            return colourExportFileDto;
        }
    }
}