using Serilog;
using WorkerServiceDemo;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog.Events;
using Microsoft.AspNetCore.Builder;


Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug().MinimumLevel
               .Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
               .Enrich.FromLogContext()
               .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug).WriteTo.Console()) // chỉ định ghi ra trên màn hình với những log debug
                 .WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information).WriteTo.Console()).CreateLogger(); // chỉ định ghi ra trên màn hình với những log debug

IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args)
    .ConfigureHostConfiguration(config =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        config.AddJsonFile("Config/connections.json", optional: false, reloadOnChange: true);
        config.AddJsonFile("Config/queryLog.json", optional: false, reloadOnChange: true);
    }).ConfigureServices(services =>
    {
        Log.Debug("starting up service");
        Log.Error("starting up service Error");
        services.AddHostedService<Worker>();
    })
    .UseSerilog((context, loggerConfiguration) =>
     {
         loggerConfiguration.ReadFrom.Configuration(context.Configuration);
     });


IHost host = hostBuilder.Build();

await host.RunAsync();
