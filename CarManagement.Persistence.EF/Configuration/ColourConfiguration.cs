using CarManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarManagement.Persistence.EF.Configuration
{
    public class ColourConfiguration : IEntityTypeConfiguration<Colour>
    {
        public void Configure(EntityTypeBuilder<Colour> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.Code)
                .IsRequired()
                .HasMaxLength(6);

        }
    }
}