using System.Collections.Generic;
using MediatR;

namespace CarManagement.Application.Features.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery  : IRequest<List<CustomerInListViewModel>>
    {
        
    }
}