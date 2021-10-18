using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Colours.Queries.GetColoursList
{
    public class GetColoursListQueryHandler : IRequestHandler<GetColoursListQuery, List<ColourInListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Colour> _colourRepository;

        public GetColoursListQueryHandler(IMapper mapper, IAsyncRepository<Colour> colourRepository)
        {
            _mapper = mapper;
            _colourRepository = colourRepository;
        }
        
        public async Task<List<ColourInListViewModel>> Handle(GetColoursListQuery request, CancellationToken cancellationToken)
        {
            var all = await _colourRepository.GetAllAsync();

            return _mapper.Map<List<ColourInListViewModel>>(all);
        }
    }
}