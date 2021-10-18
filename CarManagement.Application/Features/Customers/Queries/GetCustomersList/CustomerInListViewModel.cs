namespace CarManagement.Application.Features.Customers.Queries.GetCustomersList
{
    public class CustomerInListViewModel
    {
        public int CustomerId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string ContactNumber { get; set; }
        
        public string EmailAddress { get; set; }
    }
}