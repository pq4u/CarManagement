using CarManagement.Domain.Entities;

namespace CarManagement.Application.Features.Vehicles.Queries.GetVehiclesExport
{
    public class VehicleExportDto
    {
        public int VehicleId { get; set; }
        public int Year { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public int ColourId { get; set; }
        public Colour Colour { get; set; }
        public string Vin { get; set; }
        public string LicensePlateNumber { get; set; }
        public double RentalRate { get; set; }
    }
}