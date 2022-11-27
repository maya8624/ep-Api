using ep.Data.Persistant;
using ep.Data.Wrappers;
using ep.DataMigration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.Hosting.LifteTime", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

using IHost host = Host.CreateDefaultBuilder(args)
    .UseSerilog()
    .ConfigureAppConfiguration(config =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddEnvironmentVariables();
    })
    .ConfigureServices((context, services) =>
    {
        var cns = context.Configuration.GetConnectionString("EPDBConnection");
        services.AddDbContext<EPDbContext>(options => options.UseSqlServer(cns));
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<Migration>();
    })
    .Build();

await RunService(host.Services);
await host.RunAsync();

static async Task RunService(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    await provider.GetRequiredService<Migration>().Run();
}
