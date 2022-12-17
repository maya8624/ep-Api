using ep.Contract.Mappings;
using ep.Contract.RequestModels;
using FluentValidation;

namespace ep.API.Extensions
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
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });

            services.AddAutoMapper(typeof(APIProfile));
            services.AddHttpClient();
            services.AddControllers();
            services.AddScoped<IBusinessService, BusinessService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IValidator<BusinessRequest>, BusinessValidator>();
            services.AddScoped<IValidator<CustomerRequest>, CustomerValidator>();
            services.AddScoped<IValidator<MessageRequest>, MessageValidator>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EP", Version = "v1" });
            });
        }
    }
}
