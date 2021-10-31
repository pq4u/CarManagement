using System.Collections.Generic;
using CarManagement.Application.Features.Brands.Queries.GetBrandsExport;
using CarManagement.Application.Features.Colours.Queries.GetColoursExport;
using CarManagement.Application.Features.Customers.Queries.GetCustomersExport;
using CarManagement.Application.Features.Models.Queries.GetModelsExport;
using CarManagement.Application.Features.Vehicles.Queries.GetVehiclesExport;

namespace CarManagement.Application.Contracts.Infrastructure
{
    public interface ICsvExporter
    {
        byte[] ExportVehiclesToCsv(List<VehicleExportDto> allVehicles);
        byte[] ExportBrandsToCsv(List<BrandExportDto> allBrands);
        byte[] ExportColoursToCsv(List<ColourExportDto> allColours);
        byte[] ExportCustomersToCsv(List<CustomerExportDto> allCustomers);
        byte[] ExportModelsToCsv(List<ModelExportDto> allModels);
        byte[] ExportBookingsToCsv(List<BookingExportDto> allBookings);
    }
}