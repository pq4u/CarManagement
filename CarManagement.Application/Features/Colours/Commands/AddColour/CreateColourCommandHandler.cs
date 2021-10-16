using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Application.Features.Bookings.Commands.CreateBooking;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Colours.Commands.AddColour
{
    public class CreateColourCommandHandler : IRequestHandler<CreateColourCommand, CreateColourCommandResponse>
    {
        private readonly IColourRepository _colourRepository;
        private readonly IMapper _mapper;

        public CreateColourCommandHandler(IMapper mapper, IColourRepository colourRepository)
        {
            _mapper = mapper;
            _colourRepository = colourRepository;
        }

        public async Task<CreateColourCommandResponse> Handle(CreateColourCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateColourCommandValidator(_colourRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new CreateColourCommandResponse(validatorResult);

            var colour = _mapper.Map<Colour>(request);
            colour = await _colourRepository.AddAsync(colour);

            return new CreateColourCommandResponse(colour.ColourId);
        }
    }
}