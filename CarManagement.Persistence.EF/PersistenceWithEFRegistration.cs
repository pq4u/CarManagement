using CarManagement.Application.Contracts.Persistence;
using CarManagement.Persistence.EF.Repositories;
using CarManagement.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarManagement.Persistence.EF
{
    public static class PersistenceWithEfRegistration
    {
        public static IServiceCollection AddCarManagementPersistenceEfServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<CarManagementContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CarManagementConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IColourRepository, ColourRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();

            return services;
        }

    }
}