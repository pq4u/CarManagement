using System.Collections.Generic;

namespace CarManagement.Domain.Entities
{
    public class Vehicle : AuditableEntity
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
        
        public List<Booking> RentalRecords { get; set; }
    }
}