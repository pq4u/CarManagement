using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Infrastructure;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Application.Models.Mail;
using MediatR;

namespace CarManagement.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public DeleteCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository, IEmailService emailService)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            await _customerRepository.DeleteAsync(customer);
            
            var email = new Email()
            {
                To = "example@name.com",
                Body = $"A customer has been deleted: {request}",
                Subject = $"Deleted customer: {request}"
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