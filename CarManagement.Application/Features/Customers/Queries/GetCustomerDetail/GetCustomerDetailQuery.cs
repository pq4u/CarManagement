using CarManagement.Application.Features.Customers.Queries.GetCustomersList;
using MediatR;

namespace CarManagement.Application.Features.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQuery : IRequest<CustomerDetailViewModel>
    {
        public int Id { get; set; }
    }
}