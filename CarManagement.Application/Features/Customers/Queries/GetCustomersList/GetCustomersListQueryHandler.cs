using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarManagement.Application.Contracts.Persistence;
using CarManagement.Domain.Entities;
using MediatR;

namespace CarManagement.Application.Features.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, List<CustomerInListViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Customer> _customerRepository;

        public GetCustomersListQueryHandler(IMapper mapper, IAsyncRepository<Customer> customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        
        public async Task<List<CustomerInListViewModel>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var all = await _customerRepository.GetAllAsync();

            return _mapper.Map<List<CustomerInListViewModel>>(all);
        }
    }
}