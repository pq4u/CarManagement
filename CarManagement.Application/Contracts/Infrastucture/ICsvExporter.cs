using System.Collections.Generic;
using CarManagement.Application.Features.Brands.Queries.GetBrandsExport;

namespace CarManagement.Application.Contracts.Infrastucture
{
    public interface ICsvExporter
    {
        byte[] ExportBrandsToCsv(List<BrandExportDto> brandExportDtos);
    }
}