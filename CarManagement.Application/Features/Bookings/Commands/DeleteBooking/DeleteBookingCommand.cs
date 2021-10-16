using MediatR;

namespace CarManagement.Application.Features.Bookings.Commands.DeleteBooking
{
    public class DeleteBookingCommand : IRequest
    {
        public int BookingId { get; set; }
    }
}