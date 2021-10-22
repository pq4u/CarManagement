using CarManagement.Application.Features.Brands.Queries.GetBrandsList;
using MediatR;

namespace CarManagement.Application.Features.Brands.Queries.GetBrandDetail
{
    public class GetBrandDetailQuery : IRequest<BrandDetailViewModel>
    {
        public int Id { get; set; }
    }
}