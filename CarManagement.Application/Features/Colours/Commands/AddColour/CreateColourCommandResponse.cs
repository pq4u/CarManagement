using CarManagement.Application.Responses;
using FluentValidation.Results;

namespace CarManagement.Application.Features.Colours.Commands.AddColour
{
    public class CreateColourCommandResponse : BaseResponse
    {
        public int? ColourId { get; set; }

        public CreateColourCommandResponse() : base()
        {
        }

        public CreateColourCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }

        public CreateColourCommandResponse(string message) : base(message)
        {
        }

        public CreateColourCommandResponse(string message, bool success) : base(message, success)
        {
        }

        public CreateColourCommandResponse(int colourId)
        {
            ColourId = colourId;
        }
    }
}