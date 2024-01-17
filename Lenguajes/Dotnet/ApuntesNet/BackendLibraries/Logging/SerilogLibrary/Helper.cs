using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace SerilogLibrary;

public class Helper
{
    public static IServiceProvider GetServiceProvider()
    {
        var builder = Host.CreateDefaultBuilder();

        builder.UseSerilog((hostContext, loggerConfig) =>
        {
            loggerConfig.WriteTo.Async(config =>
            {
                config.Seq(hostContext.Configuration["ConnectionStrings:SeqConnectionString"]!, LogEventLevel.Information);
                config.Console(LogEventLevel.Debug);
            });
        });

        var app = builder.Build();

        return app.Services;
    }
}
