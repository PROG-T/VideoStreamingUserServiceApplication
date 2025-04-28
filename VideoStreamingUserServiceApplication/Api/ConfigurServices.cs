using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace VideoStreamingUserServiceApplication.Api
{
    public static class ConfigurServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
            {
                options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen( c =>
            {
                c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer
                {
                    Url = "https://localhost:8976",
                    Description = "Local host"
                });
                c.SwaggerDoc("API", new OpenApiInfo { Title = $"{builder.Environment.ApplicationName}", Version = builder.Configuration["Swagger:Version"] });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                  Scheme = "Bearer",
                  BearerFormat = "JWT",
                  In = ParameterLocation.Header,
                  Name = "Authorization",
                  Description = "Bearer Authentication with JWT Token",
                  Type = SecuritySchemeType.Http
                });
                c.CustomSchemaIds(x => x.FullName);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });

            });
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddCors(options => 
                options.AddPolicy("", corsPolicyOptions => {
                    corsPolicyOptions.AllowAnyMethod();
                    corsPolicyOptions.AllowAnyHeader();
                    corsPolicyOptions.AllowCredentials();
                    corsPolicyOptions.SetIsOriginAllowed(origin => {
                    if (String.IsNullOrWhiteSpace(origin)) return false;
                        if (origin.StartsWith("http://localhost", StringComparison.CurrentCultureIgnoreCase)) return true;
                        if (origin.StartsWith("https://localhost", StringComparison.CurrentCultureIgnoreCase)) return true;
                        return false;
                    });

                })
                );

            return services;
        }
    }
}
