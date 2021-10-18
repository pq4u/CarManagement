using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Brands.Queries.GetBrandsList
{
    public class GetBrandsListQueryHandler : IRequestHandler<GetBrandsListQuery, List<BrandInListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Brand> _brandRepository;

        public GetBrandsListQueryHandler(IMapper mapper, IAsyncRepository<Brand> brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }
        
        public async Task<List<BrandInListViewModel>> Handle(GetBrandsListQuery request, CancellationToken cancellationToken)
        {
            var all = await _brandRepository.GetAllAsync();

            return _mapper.Map<List<BrandInListViewModel>>(all);
        }
    }
}