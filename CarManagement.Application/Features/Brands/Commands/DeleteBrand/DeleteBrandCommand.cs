using MediatR;

namespace CarManagement.Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand : IRequest
    {
        public int BrandId { get; set; }
    }
}