using ep.API.Service.Hubs;
using ep.Service.Email;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace ep.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            //Services.AddEndpointsApiExplorer();

            var emailConfig = Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddServices();
            services.AddDbContext<EPDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("EPDBConnection"), x => x.MigrationsAssembly("ep.API"))
            );

            services.AddFluentValidationAutoValidation();
            services.AddSignalR()
            .AddAzureSignalR("Endpoint=https://andytestsignalr.service.signalr.net;AccessKey=FE3k5ebX2WowT11Xl9zJN7m3SCePxqYSwc0qJEKWqpQ=;Version=1.0;");

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("outh2", new OpenApiSecurityScheme
                {
                    Description = "Authorization header using the Bearer scheme(\"bearer {token\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                 .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Secret").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseSwagger();
            
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EP v1"));

            app.UseCors();
                        
            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseAuthentication();
            app.UseAuthorization();
                  
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<CustomerHub>("/hub/customer");
                endpoints.MapControllers();
            });
        }
    }
}
