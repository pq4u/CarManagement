using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using MediatR;

namespace CarManagement.Application.Features.Colours.Commands.DeleteColour
{
    public class DeleteColourCommandHandler : IRequestHandler<DeleteColourCommand>
    {
        private readonly IColourRepository _colourRepository;
        private readonly IMapper _mapper;

        public DeleteColourCommandHandler(IMapper mapper, IColourRepository colourRepository)
        {
            _mapper = mapper;
            _colourRepository = colourRepository;
        }

        public async Task<Unit> Handle(DeleteColourCommand request, CancellationToken cancellationToken)
        {
            var colour = await _colourRepository.GetByIdAsync(request.ColourId);
            await _colourRepository.DeleteAsync(colour);
            
            return Unit.Value;
        }
    }
}