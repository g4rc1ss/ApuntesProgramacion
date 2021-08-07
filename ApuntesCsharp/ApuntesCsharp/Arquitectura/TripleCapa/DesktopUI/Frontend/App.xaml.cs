using System.Windows;
using Backend.Business;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Frontend {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            CreateHostBuilder(e.Args).Build().RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) {
            return new HostBuilder()
                .UseEnvironment(System.Environment.GetEnvironmentVariable("WPF_ENVIRONMENT") ?? "Production")
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

                    var presentation = services.BuildServiceProvider().GetRequiredService<MainWindow>();
                    presentation.Show();
                });
        }
    }
}
