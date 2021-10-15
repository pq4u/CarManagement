namespace CarManagement.Domain.Entities
{
    public class Brand : AuditableEntity
    {
        public int BrandId { get; set; }

        public string Name { get; set; }
    }
}