using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Infrastructure;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Application.Models.Mail;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, CreateBookingCommandResponse>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateBookingCommandHandler(IBookingRepository bookingRepository, IMapper mapper, IEmailService emailService)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _emailService = emailService;
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
            
            var email = new Email()
            {
                To = "example@name.com",
                Body = $"A new booking has been created: {request}",
                Subject = $"New booking: {request}"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {

            }

            return new CreateBookingCommandResponse(booking.BookingId);
        }
    }
}