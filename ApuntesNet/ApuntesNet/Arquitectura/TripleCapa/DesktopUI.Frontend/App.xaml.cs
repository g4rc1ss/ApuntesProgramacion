using System.Data;
using System.Windows;
using DesktopUI.Backend.Business;
using DesktopUI.Backend.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DesktopUI.Frontend {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            CreateHostBuilder(e.Args).Build();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) {
            return new HostBuilder()
                .UseEnvironment(System.Environment.GetEnvironmentVariable("DESKTOP_ENVIRONMENT") ?? "Production")
                .ConfigureAppConfiguration((hostContext, configBuilder) => {
                    _ = configBuilder.AddJsonFile("appsettings.json");
                    _ = configBuilder.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                })
                .ConfigureServices((hostContext, services) => {
                    _ = services.AddOptions();

                    _ = services.AddFrontend();
                    _ = services.AddBackendBusiness();
                    _ = services.AddBackendData();

                    _ = services.AddDbContextFactory<ContextoSqlServer>(options => {
                        options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(ContextoSqlServer)));
                    });
                    _ = services.AddScoped(p => p.GetRequiredService<IDbContextFactory<ContextoSqlServer>>().CreateDbContext());

                    var presentation = services.BuildServiceProvider().GetRequiredService<MainWindow>();
                    presentation.Show();
                });
        }
    }
}
