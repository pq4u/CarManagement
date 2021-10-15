namespace CarManagement.Domain.Entities
{
    public class Customer : AuditableEntity
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