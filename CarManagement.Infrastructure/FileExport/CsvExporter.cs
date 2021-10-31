using System.Collections.Generic;
using System.IO;
using CarManagement.Application.Contracts.Infrastructure;
using CarManagement.Application.Features.Brands.Queries.GetBrandsExport;
using CarManagement.Application.Features.Colours.Queries.GetColoursExport;
using CarManagement.Application.Features.Customers.Queries.GetCustomersExport;
using CarManagement.Application.Features.Models.Queries.GetModelsExport;
using CarManagement.Application.Features.Vehicles.Queries.GetVehiclesExport;
using CsvHelper;

namespace CarManagement.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportBookingsToCsv(List<BookingExportDto> bookingExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(bookingExportDtos);
            }

            return memoryStream.ToArray();
        }
        
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
        
        public byte[] ExportCustomersToCsv(List<CustomerExportDto> customerExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(customerExportDtos);
            }

            return memoryStream.ToArray();
        }
        
        
        public byte[] ExportColoursToCsv(List<ColourExportDto> colourExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(colourExportDtos);
            }

            return memoryStream.ToArray();
        }
        
        public byte[] ExportModelsToCsv(List<ModelExportDto> modelExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(modelExportDtos);
            }

            return memoryStream.ToArray();
        }
        
        public byte[] ExportVehiclesToCsv(List<VehicleExportDto> vehicleExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter);
                csvWriter.WriteRecords(vehicleExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}