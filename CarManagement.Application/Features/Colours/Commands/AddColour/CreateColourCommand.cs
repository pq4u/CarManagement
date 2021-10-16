using CarManagement.Application.Features.Bookings.Commands.CreateBooking;
using MediatR;

namespace CarManagement.Application.Features.Colours.Commands.AddColour
{
    public class CreateColourCommand : IRequest<CreateColourCommandResponse>
    {
        public int ColourId { get; set; }
        
        public string Name { get; set; }
        
        public string Code { get; set; }
    }
}