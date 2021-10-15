using System;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : IRequest<CreateBookingCommandResponse>
    {
        public int BookingId { get; set; }
        
        public int VehicleId { get; set; }
        
        public Vehicle Vehicle { get; set; }
        
        public DateTime DateOut { get; set; }
        
        public DateTime DateIn { get; set; }
        
        public Customer Customer { get; set; }
        
        public int CustomerId { get; set; }
    }
}