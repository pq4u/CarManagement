using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Colours.Commands.EditColour
{
    public class UpdateColourCommandHandler : IRequestHandler<UpdateColourCommand>
    {
        private readonly IColourRepository _colourRepository;
        private readonly IMapper _mapper;

        public UpdateColourCommandHandler(IColourRepository colourRepository, IMapper mapper)
        {
            _colourRepository = colourRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateColourCommand request, CancellationToken cancellationToken)
        {
            var colour = _mapper.Map<Colour>(request);

            await _colourRepository.UpdateAsync(colour);
            return Unit.Value;
        }
    }
}