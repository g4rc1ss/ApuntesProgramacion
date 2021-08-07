using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Migrations {
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
                        options.UseSqlite(hostContext.Configuration.GetConnectionString(nameof(ContextoSqlServer)), sql => {
                            sql.MigrationsAssembly(typeof(Program).Assembly.FullName);
                        });
                    });
                    services.AddScoped(p => p.GetRequiredService<IDbContextFactory<ContextoSqlServer>>().CreateDbContext());

                    // Agregamos el tipo de clase DatabaseMigrator para crear la bbdd a traves de las migraciones y contextos
                    services.AddTransient<DatabaseMigrator>();

                    //// Creamos unas clases para incializar la base de datos con datos una vez creada.
                    services.AddTransient<DatabaseInitializer>();
                    //// Scaneamos y ejecutamos el Seed correspondiente para inicializar la BBDD
                    services.Scan(scan => scan.FromAssemblyOf<DatabaseInitializer>()
                        .AddClasses(@class => @class.AssignableTo<IDataSeed>())
                        .As<IDataSeed>()
                        .WithTransientLifetime());

                    services.AddHostedService<MigrationService>();
                });
        }
    }
}
