using ePager.Data.Wrappers;
using ePager.Domain.Mappings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ePager.API.Extensions
{
    public static class ServiceExtensions
    { 
        public static void AddServices(this IServiceCollection services)
        {           
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                                        .AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                    });
            });

            services.AddAutoMapper(typeof(APIProfile));
            services.AddHttpClient();
            services.AddControllers();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EP", Version = "v1" });
            });
        }
    }
}
