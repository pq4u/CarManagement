using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, CreateBookingCommandResponse>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public CreateBookingCommandHandler(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<CreateBookingCommandResponse> Handle(CreateBookingCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new CreateBookingCommandValidator(_bookingRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new CreateBookingCommandResponse(validatorResult);

            var booking = _mapper.Map<Booking>(request);
            booking = await _bookingRepository.AddAsync(booking);

            return new CreateBookingCommandResponse(booking.BookingId);
        }
    }
}