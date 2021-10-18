using System;

namespace CarManagement.Application.Features.Bookings.Queries.GetBookingsList
{
    public class BookingInListViewModel
    {
        public int BookingId { get; set; }
        public string Title { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
    }
}