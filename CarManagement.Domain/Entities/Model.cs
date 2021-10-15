namespace CarManagement.Domain.Entities
{
    public class Model : AuditableEntity
    {
        public int ModelId { get; set; }
        
        public string Name { get; set; }
    }
}