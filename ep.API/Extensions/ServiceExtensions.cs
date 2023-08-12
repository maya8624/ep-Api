using ep.Contract.Mappings;
using ep.Contract.RequestModels;
using ep.Logic.Interfaces;
using ep.Logic.Logics;
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
            services.AddScoped<IAuthLogic, AuthLogic>();
            services.AddScoped<IBusinessLogic, BusinessLogic>();
            services.AddScoped<ICustomerLogic, CustomerLogic>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IUserLogic, UserLogic>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IValidator<BusinessRequest>, BusinessValidator>();
            services.AddScoped<IValidator<CustomerRequest>, CustomerValidator>();
            services.AddScoped<IValidator<LogInRequest>, LogInValidator>();
            services.AddScoped<IValidator<MessageRequest>, MessageValidator>();
            services.AddScoped<IValidator<RegisterRequest>, RegisterValidator>();
            services.AddScoped<IValidator<ServiceBusRequest>, ServiceBusRequestValidator>();            
        }
    }
}
