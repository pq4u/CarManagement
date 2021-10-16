using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreateBrandCommandResponse>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<CreateBrandCommandResponse> Handle(CreateBrandCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new CreateBrandCommandValidator(_brandRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new CreateBrandCommandResponse(validatorResult);

            var brand = _mapper.Map<Brand>(request);
            brand = await _brandRepository.AddAsync(brand);

            return new CreateBrandCommandResponse(brand.BrandId);
        }
    }
}