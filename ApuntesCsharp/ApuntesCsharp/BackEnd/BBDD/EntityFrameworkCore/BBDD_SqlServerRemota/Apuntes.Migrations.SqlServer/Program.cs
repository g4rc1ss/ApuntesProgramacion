using Apuntes.Back.Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Apuntes.Migrations.SqlServer {
    internal class Program {
        private static void Main(string[] args) {
            CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) {
            return new HostBuilder()
                .UseEnvironment("Development")
                .ConfigureAppConfiguration((hostContext, configBuilder) => {
                    configBuilder.AddJsonFile("appsettings.json");
                })
                .ConfigureLogging((ctx, l) => {
                    l.AddConfiguration(ctx.Configuration);
                    l.AddConsole();
                })
                .ConfigureServices((hostContext, services) => {
                    services.AddOptions();

                    //Debugger.Launch();
                    // La instruccion de abajo se usa cuando hay configuracion inicial, sino se hace como aqui
                    // Se utiliza el "OnConfiguring()" correspondiente al contexto
                    services.AddDbContext<ContextoMSSQL>(options => {
                        //ConfigurationManager.ConnectionStrings[nameof(ContextoMSSQL)].ConnectionString, sql => {
                        options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(ContextoMSSQL)), sql => {
                            sql.MigrationsAssembly(typeof(Program).Assembly.FullName);
                        });
                    });

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
