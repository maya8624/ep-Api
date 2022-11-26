using ep.Data.Persistant;
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
        //services.AddSingleton<ITrustApiRepository, TrustApiRepository>();
        services.AddSingleton<Migration>();
    })
    .Build();

RunService(host.Services);
await host.RunAsync();

static void RunService(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;
    provider.GetRequiredService<Migration>().Run();
}
