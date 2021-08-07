using DesktopUI.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DesktopUI.Migrations {
    internal class Program {
        private static void Main(string[] args) {
            _ = CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) {
            return new HostBuilder()
                .UseEnvironment(System.Environment.GetEnvironmentVariable("CONSOLE_ENVIRONMENT") ?? "Production")
                .ConfigureAppConfiguration((hostContext, configBuilder) => {
                    _ = configBuilder.AddJsonFile("appsettings.json");
                    _ = configBuilder.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                })
                .ConfigureLogging((ctx, l) => {
                    _ = l.AddConfiguration(ctx.Configuration);
                    _ = l.AddConsole();
                })
                .ConfigureServices((hostContext, services) => {
                    _ = services.AddOptions();

                    _ = services.AddDbContextFactory<ContextoSqlServer>(options => {
                        _ = options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(ContextoSqlServer)), sql => {
                            _ = sql.MigrationsAssembly(typeof(Program).Assembly.FullName);
                        });
                    });
                    _ = services.AddScoped(p => p.GetRequiredService<IDbContextFactory<ContextoSqlServer>>().CreateDbContext());

                    // Agregamos el tipo de clase DatabaseMigrator para crear la bbdd a traves de las migraciones y contextos
                    _ = services.AddTransient<DatabaseMigrator>();

                    //// Creamos unas clases para incializar la base de datos con datos una vez creada.
                    _ = services.AddTransient<DatabaseInitializer>();
                    //// Scaneamos y ejecutamos el Seed correspondiente para inicializar la BBDD
                    _ = services.Scan(scan => scan.FromAssemblyOf<DatabaseInitializer>()
                          .AddClasses(@class => @class.AssignableTo<IDataSeed>())
                          .As<IDataSeed>()
                          .WithTransientLifetime());

                    _ = services.AddHostedService<MigrationService>();
                });
        }
    }
}
