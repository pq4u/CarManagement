using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Vehicles.Commands.EditVehicle
{
    public class UpdateVehicleCommand : IRequest
    {
        public int VehicleId { get; set; }
        
        public int Year { get; set; }
        
        public int ModelId { get; set; }
        
        public Model Model { get; set; }
        
        public int MakeId { get; set; }
        
        public Brand Brand { get; set; }
        
        public int ColourId { get; set; }
        
        public Colour Colour { get; set; }
        
        public string Vin { get; set; }
        
        public string LicensePlateNumber { get; set; }
        
        public double RentalRate { get; set; }
    }
}