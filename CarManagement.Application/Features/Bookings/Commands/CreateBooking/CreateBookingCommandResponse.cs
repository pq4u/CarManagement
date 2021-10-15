using CarManagement.Application.Responses;
using FluentValidation.Results;

namespace CarManagement.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandResponse : BaseResponse
    {
        public int? BookingId { get; set; }

        public CreateBookingCommandResponse() : base()
        {
        }

        public CreateBookingCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }

        public CreateBookingCommandResponse(string message) : base(message)
        {
        }

        public CreateBookingCommandResponse(string message, bool success) : base(message, success)
        {
        }

        public CreateBookingCommandResponse(int bookingId)
        {
            BookingId = bookingId;
        }
    }
}