using System.Collections.Generic;
using MediatR;

namespace CarManagement.Application.Features.Brands.Queries.GetBrandsList
{
    public class GetBrandsListQuery : IRequest<List<BrandInListViewModel>>
    {
        
    }
}