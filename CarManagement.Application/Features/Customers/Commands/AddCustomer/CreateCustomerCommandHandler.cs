using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Customers.Commands.AddCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

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

            return new CreateCustomerCommandResponse(customer.CustomerId);
        }
    }
}