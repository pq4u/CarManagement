using System.Collections.Generic;
using CarManagement.Application.Features.Vehicles.Queries.GetVehicleDetail.Dtos;
using CarManagement.Domain.Entities;

namespace CarManagement.Application.Features.Vehicles.Queries.GetVehicleDetail
{
    public class VehicleDetailViewModel
    {
        public int VehicleId { get; set; }
        
        public int Year { get; set; }
        
        public int ModelId { get; set; }
        
        public ModelDto Model { get; set; }
        
        public int BrandId { get; set; }
        
        public BrandDto Brand { get; set; }
        
        public int ColourId { get; set; }
        
        public ColourDto Colour { get; set; }
        
        public string Vin { get; set; }
        
        public string LicensePlateNumber { get; set; }
        
        public double RentalRate { get; set; }
        
        public List<BookingDto> RentalRecords { get; set; }
    }
}