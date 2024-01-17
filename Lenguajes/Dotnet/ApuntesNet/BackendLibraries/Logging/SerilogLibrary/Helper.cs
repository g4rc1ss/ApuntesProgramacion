using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace SerilogLibrary;

public class Helper
{
    public static IServiceProvider GetServiceProvider()
    {
        var builder = Host.CreateDefaultBuilder();

        builder.ConfigureLogging(log =>
        {
            log.ClearProviders();
            log.AddConsole();
            log.SetMinimumLevel(LogLevel.Trace);
        });
        builder.UseSerilog((hostContext, loggerConfig) =>
        {
            loggerConfig.WriteTo.Seq(hostContext.Configuration["ConnectionStrings:SeqConnectionString"]!);
            loggerConfig.WriteTo.Console();
        });

        var app = builder.Build();

        return app.Services;
    }
}
