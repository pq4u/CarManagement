using System;
using CarManagement.Domain.Entities;

namespace CarManagement.Application.Features.Models.Queries.GetModelsExport
{
    public class BookingExportDto
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