using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Infrastructure;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Application.Models.Mail;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Customers.Commands.AddCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerCommandValidator(_customerRepository);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid)
                return new CreateCustomerCommandResponse(validatorResult);

            var customer = _mapper.Map<Customer>(request);
            customer = await _customerRepository.AddAsync(customer);

            var email = new Email()
            {
                To = "example@name.com",
                Body = $"A new customer has been created: {request}",
                Subject = $"New customer: {request}"
            };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {

            }
            
            return new CreateCustomerCommandResponse(customer.CustomerId);
        }
    }
}