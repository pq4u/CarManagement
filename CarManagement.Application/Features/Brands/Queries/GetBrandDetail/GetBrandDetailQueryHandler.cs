using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Brands.Queries.GetBrandDetail
{
    public class GetBrandDetailQueryHandler : IRequestHandler<GetBrandDetailQuery, BrandDetailViewModel>
    {
        private readonly IAsyncRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;

        public GetBrandDetailQueryHandler(IMapper mapper, IAsyncRepository<Brand> brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public async Task<BrandDetailViewModel> Handle(GetBrandDetailQuery request,
            CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(request.Id);
            var brandDetail = _mapper.Map<BrandDetailViewModel>(brand);

            return brandDetail;
        }
    }
}