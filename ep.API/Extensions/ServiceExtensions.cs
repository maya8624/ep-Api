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
                                        //.AllowAnyOrigin()
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowCredentials();
                    });
            });

            services.AddAutoMapper(typeof(APIProfile));
            services.AddHttpClient();
            services.AddControllers();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EP", Version = "v1" });
            });
        }
    }
}
