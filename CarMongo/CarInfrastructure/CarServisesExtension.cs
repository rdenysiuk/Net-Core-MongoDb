using CarDL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarInfrastructure
{
    public static class CarServisesExtension
    {
        public static IServiceCollection AddCarServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutomapperProfile();
            services.AddMongoDbService(configuration);
            return services;
        }
    }
}
