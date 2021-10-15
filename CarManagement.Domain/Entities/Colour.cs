namespace CarManagement.Domain.Entities
{
    public class Colour : AuditableEntity
    {
        public int ColourId { get; set; }
        
        public string Name { get; set; }
        
        public string Code { get; set; }
    }
}