using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace SerilogLibrary
{
    public class Helper
    {
        public static IServiceProvider GetServiceProvider()
        {
            var builder = Host.CreateDefaultBuilder();

            builder.UseSerilog((hostContext, loggerConfig) =>
            {
                loggerConfig.WriteTo.Async(config =>
                {
                    //config.MSSqlServer(
                    //    connectionString: connectionString,
                    //    new MSSqlServerSinkOptions
                    //    {
                    //        SchemaName = "dbo",
                    //        TableName = "Logs",
                    //        AutoCreateSqlTable = true,
                    //    },
                    //    restrictedToMinimumLevel: LogEventLevel.Warning);

                    config.Console(LogEventLevel.Debug);
                });
            });

            builder.ConfigureServices(services =>
            {

            });

            var app = builder.Build();

            return app.Services;
        }
    }
}
