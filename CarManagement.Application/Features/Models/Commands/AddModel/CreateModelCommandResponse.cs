using CarManagement.Application.Responses;
using FluentValidation.Results;

namespace CarManagement.Application.Features.Models.Commands.AddModel
{
    public class CreateModelCommandResponse : BaseResponse
    {
        public int? ModelId { get; set; }

        public CreateModelCommandResponse() : base()
        {
        }

        public CreateModelCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }

        public CreateModelCommandResponse(string message) : base(message)
        {
        }

        public CreateModelCommandResponse(string message, bool success) : base(message, success)
        {
        }

        public CreateModelCommandResponse(int modelId)
        {
            ModelId = modelId;
        }
    }
}