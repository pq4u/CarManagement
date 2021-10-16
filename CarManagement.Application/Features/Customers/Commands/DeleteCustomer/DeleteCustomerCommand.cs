using MediatR;

namespace CarManagement.Application.Features.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public int CustomerId { get; set; }
    }
}