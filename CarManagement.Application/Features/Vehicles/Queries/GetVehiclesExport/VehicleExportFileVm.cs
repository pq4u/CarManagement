using MediatR;

namespace CarManagement.Application.Features.Vehicles.Queries.GetVehiclesExport
{
    public class VehicleExportFileVm
    {
        public string VehicleExportFileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}