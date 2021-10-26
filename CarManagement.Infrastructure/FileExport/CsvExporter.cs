using System.Collections.Generic;
using System.IO;
using CarManagement.Application.Contracts.Infrastucture;
using CarManagement.Application.Features.Brands.Queries.GetBrandsExport;
using CsvHelper;

namespace CarManagement.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportBrandsToCsv(List<BrandExportDto> brandExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(brandExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}