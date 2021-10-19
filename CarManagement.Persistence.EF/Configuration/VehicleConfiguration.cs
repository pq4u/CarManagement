using CarManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarManagement.Persistence.EF.Configuration
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.Property(e => e.Brand)
                .IsRequired();
            
            builder.Property(e => e.Model)
                .IsRequired();
            
            builder.Property(e => e.Year)
                .IsRequired();
        }
    }
}