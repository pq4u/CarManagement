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

namespace CarManagement.Application.Features.Brands.Queries.GetBrandsExport
{
    public class GetBrandsExportQueryHandler : IRequestHandler<GetBrandsExportQuery, BrandExportFileVm>
    {
        private readonly IAsyncRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetBrandsExportQueryHandler(IMapper mapper, IAsyncRepository<Brand> brandRepository, ICsvExporter csvExporter)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
            _csvExporter = csvExporter;
        }

        public async Task<BrandExportFileVm> Handle(GetBrandsExportQuery request, CancellationToken cancellationToken)
        {
            var allBrands = _mapper.Map<List<BrandExportDto>>((await _brandRepository.GetAllAsync()));

            var fileData = _csvExporter.ExportBrandsToCsv(allBrands);

            var brandExportFileDto = new BrandExportFileVm() { ContentType = "text/csv", Data = fileData, BrandExportFileName = $"{Guid.NewGuid()}.csv" };

            return brandExportFileDto;
        }
    }
}