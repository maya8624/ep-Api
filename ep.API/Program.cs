using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation.AspNetCore;
using ep.Service.Email;
using ep.API.Service.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();

var emailConfig = builder.Configuration
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();

builder.Services.AddSingleton(emailConfig);
builder.Services.AddServices();

builder.Services.AddDbContext<EPDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EPDBConnection"), x => x.MigrationsAssembly("ep.API"))
);

builder.Services.AddSignalR()
           .AddAzureSignalR("Endpoint=https://andytestsignalr.service.signalr.net;AccessKey=FE3k5ebX2WowT11Xl9zJN7m3SCePxqYSwc0qJEKWqpQ=;Version=1.0;");

builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "EP", Version = "v1" });
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Secret").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<CustomerHub>("/hub/customer");
    endpoints.MapControllers();
});

//app.MapControllers();

app.Run();
