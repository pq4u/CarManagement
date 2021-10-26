using CarManagement.Application.Contracts.Infrastucture;
using CarManagement.Infrastructure.FileExport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarManagement.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<ICsvExporter, CsvExporter>();

            return services;
        }

    }
}