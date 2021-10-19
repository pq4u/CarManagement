using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CarManagement.Application
{
    public static class ApplicationInstallation
    {
        public static IServiceCollection AddCarManagementApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}