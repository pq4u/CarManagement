using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Infrastructure;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Application.Models.Mail;
using MediatR;

namespace CarManagement.Application.Features.Bookings.Commands.DeleteBooking
{
    public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public DeleteBookingCommandHandler(IBookingRepository bookingRepository, IMapper mapper, IEmailService emailService)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<Unit> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = await _bookingRepository.GetByIdAsync(request.BookingId);
            await _bookingRepository.DeleteAsync(booking);
            
            
            var email = new Email()
            {
                To = "example@name.com",
                Body = $"A booking has been deleted: {request}",
                Subject = $"Deleted booking: {request}"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {

            }
            return Unit.Value;
        }
    }
}