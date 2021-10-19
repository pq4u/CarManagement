using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarManagement.Domain.Entities;

namespace CarManagement.Persistence.EntityFramework
{
    public class CarManagementContext : DbContext
    {
        public CarManagementContext(DbContextOptions<CarManagementContext> options)
            : base(options)
        {
        }
        
        
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Colour> Colours { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}