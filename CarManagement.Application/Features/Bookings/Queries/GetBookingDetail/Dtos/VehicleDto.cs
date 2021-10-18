using System.Collections.Generic;
using CarManagement.Domain.Entities;

namespace CarManagement.Application.Features.Bookings.Queries.GetBookingDetail.Dtos
{
    public class VehicleDto
    {
        public int VehicleId { get; set; }
        
        public string LicensePlateNumber { get; set; }
        
        public double RentalRate { get; set; }
        
        public List<Booking> RentalRecords { get; set; }
    }
}