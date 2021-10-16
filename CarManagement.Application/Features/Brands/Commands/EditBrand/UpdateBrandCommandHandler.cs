using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Brands.Commands.EditBrand
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public async Task<Unit> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<Brand>(request);

            await _brandRepository.UpdateAsync(brand);
            return Unit.Value;
        }
    }
}