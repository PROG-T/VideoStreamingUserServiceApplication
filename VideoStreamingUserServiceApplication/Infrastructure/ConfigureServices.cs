using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using VideoStreamingUserServiceApplication.Applications.Common.Interfaces;
using VideoStreamingUserServiceApplication.Infrastructure.Persistence;
using VideoStreamingUserServiceApplication.Infrastructure.Repository;
using VideoStreamingUserServiceApplication.Infrastructure.Services;

namespace VideoStreamingUserServiceApplication.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuaration) {

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuaration.GetConnectionString("DefaultConnection"), builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
            services.AddScoped<IJwtService,JwtService>();
            services.AddScoped<IPasswordService,PasswordService>();
            services.AddScoped<IUnitOfWorkRepository,UnitOfWorkRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            
            return services;
        }
    }
}
