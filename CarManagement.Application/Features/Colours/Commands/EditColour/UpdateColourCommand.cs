using MediatR;

namespace CarManagement.Application.Features.Colours.Commands.EditColour
{
    public class UpdateColourCommand : IRequest
    {
        public int ColourId { get; set; }
                
        public string Name { get; set; }
                
        public string Code { get; set; }
    }
}