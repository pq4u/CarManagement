using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Colours.Queries.GetColourDetail
{
    public class GetColourDetailQueryHandler : IRequestHandler<GetColourDetailQuery, ColourDetailViewModel>
    {
        private readonly IAsyncRepository<Colour> _colourRepository;
        private readonly IMapper _mapper;

        public GetColourDetailQueryHandler(IMapper mapper, IAsyncRepository<Colour> colourRepository)
        {
            _mapper = mapper;
            _colourRepository = colourRepository;
        }

        public async Task<ColourDetailViewModel> Handle(GetColourDetailQuery request,
            CancellationToken cancellationToken)
        {
            var colour = await _colourRepository.GetByIdAsync(request.Id);
            var colourDetail = _mapper.Map<ColourDetailViewModel>(colour);

            return colourDetail;
        }
    }
}