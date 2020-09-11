using AutoMapper;
using CarDL.Mapping;
using Microsoft.Extensions.DependencyInjection;

namespace CarDL.Services
{
    public static class AutoMapperProfileExtension
    {
        public static IServiceCollection AddAutomapperProfile(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
