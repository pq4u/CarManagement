using MediatR;

namespace CarManagement.Application.Features.Customers.Commands.EditCustomer
{
    public class UpdateCustomerCommand : IRequest
    {
        public int CustomerId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Street { get; set; }
        
        public string ZipCode { get; set; }
        
        public string City { get; set; }
        
        public string ContactNumber { get; set; }
        
        public string EmailAddress { get; set; }
    }
}