using MediatR;

namespace CarManagement.Application.Features.Brands.Commands.EditBrand
{
    public class UpdateBrandCommand : IRequest
    {
        public int BrandId { get; set; }

        public string Name { get; set; }
    }
}