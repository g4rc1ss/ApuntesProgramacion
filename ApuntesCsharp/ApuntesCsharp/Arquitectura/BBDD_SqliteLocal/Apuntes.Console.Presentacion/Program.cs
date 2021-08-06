using Apuntes.BackLocal.Core;
using Apuntes.BackLocal.DataAccessLayer.Database;
using Apuntes.Console.Presentacion.Console.Usuarios;
using InmobiliariaEguzkimendi.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Apuntes.Console.Presentacion {
    public class Program {
        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) {
            return new HostBuilder()
                .UseEnvironment(System.Environment.GetEnvironmentVariable("CONSOLE_ENVIRONMENT") ?? "Production")
                .ConfigureAppConfiguration((hostContext, configBuilder) => {
                    configBuilder.AddJsonFile("appsettings.json");
                    configBuilder.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                })
                .ConfigureServices((hostContext, services) => {
                    services.AddOptions();

                    services.AddApuntesConsolePresentacion();
                    services.AddApuntesBackLocalCore();
                    services.AddApuntesDataAccessLayer();

                    services.AddDbContextFactory<ContextoSqlite>(options => {
                        options.UseSqlite(hostContext.Configuration.GetConnectionString(nameof(ContextoSqlite)));
                    });
                    services.AddScoped(p => p.GetRequiredService<IDbContextFactory<ContextoSqlite>>().CreateDbContext());
                    var presentation = services.BuildServiceProvider().GetRequiredService<MainConsole>();
                    presentation.EntradaApp();
                });
        }
    }
}
