using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using MediatR;

namespace CarManagement.Application.Features.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand>
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;

        public DeleteBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
        }


        public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _brandRepository.GetByIdAsync(request.BrandId);
            await _brandRepository.DeleteAsync(brand);
            
            return Unit.Value;
        }
    }
}