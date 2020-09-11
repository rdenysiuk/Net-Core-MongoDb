using CarBL.Interfaces;
using CarBL.Services;
using CarDL.DBContext;
using CarDL.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarDL.Services
{
    public static class ServiceDBExtension
    {
        public static IServiceCollection AddMongoDbService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoSettings>(options => {
                options.Connection = configuration.GetSection("MongoSettings:Connection").Value;
                options.DatabaseName = configuration.GetSection("MongoSettings:DatabaseName").Value;
            });
            services.AddSingleton<IMongoCarDbContext, MongoCarDbContext>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarService, CarService>();

            return services;
        }
    }
}
