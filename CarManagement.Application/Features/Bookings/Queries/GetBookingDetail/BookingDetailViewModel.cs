using System;
using CarManagement.Application.Features.Bookings.Queries.GetBookingDetail.Dtos;

namespace CarManagement.Application.Features.Bookings.Queries.GetBookingDetail
{
    public class BookingDetailViewModel
    {
        public int BookingId { get; set; }
        
        public VehicleDto Vehicle { get; set; }
        
        public DateTime DateOut { get; set; }
        
        public DateTime DateIn { get; set; }
        
        public CustomerDto Customer { get; set; }
    }
}