using System;

namespace CarManagement.Application.Features.Vehicles.Queries.GetVehicleDetail.Dtos
{
    public class BookingDto
    {
        public int BookingId { get; set; }

        public string Title { get; set; }
        
        public DateTime DateOut { get; set; }
        
        public DateTime DateIn { get; set; }
    }
}