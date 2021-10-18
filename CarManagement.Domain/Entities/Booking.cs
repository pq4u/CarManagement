using System;
using System.Collections.Generic;

namespace CarManagement.Domain.Entities
{
    public class Booking : AuditableEntity
    {
        public int BookingId { get; set; }

        public string Title { get; set; }
        
        public int VehicleId { get; set; }
        
        public Vehicle Vehicle { get; set; }
        
        public DateTime DateOut { get; set; }
        
        public DateTime DateIn { get; set; }
        
        public Customer Customer { get; set; }
        
        public int CustomerId { get; set; }
    }
}