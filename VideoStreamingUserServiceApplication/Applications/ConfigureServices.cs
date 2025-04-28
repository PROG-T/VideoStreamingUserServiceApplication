using AutoMapper.Internal;
using System.Reflection;

namespace VideoStreamingUserServiceApplication.Applications
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddAutoMapper(cfg => cfg.Internal().MethodMappingEnabled = false, Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;

        }
    }
}
