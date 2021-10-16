using CarManagement.Application.Responses;
using FluentValidation.Results;

namespace CarManagement.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandResponse : BaseResponse
    {
        public int? BrandId { get; set; }

        public CreateBrandCommandResponse() : base()
        {
        }

        public CreateBrandCommandResponse(ValidationResult validationResult) : base(validationResult)
        {
        }

        public CreateBrandCommandResponse(string message) : base(message)
        {
        }

        public CreateBrandCommandResponse(string message, bool success) : base(message, success)
        {
        }

        public CreateBrandCommandResponse(int brandId)
        {
            BrandId = brandId;
        }
    }
}