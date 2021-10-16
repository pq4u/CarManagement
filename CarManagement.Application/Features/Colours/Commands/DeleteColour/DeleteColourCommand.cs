using MediatR;

namespace CarManagement.Application.Features.Colours.Commands.DeleteColour
{
    public class DeleteColourCommand : IRequest
    {
        public int ColourId { get; set; }
    }
}