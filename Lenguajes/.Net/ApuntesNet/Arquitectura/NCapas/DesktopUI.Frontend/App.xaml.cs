using System.Windows;
using DesktopUI.Backend.Business;
using DesktopUI.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DesktopUI.Frontend
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = Host.CreateDefaultBuilder(e.Args);

            builder.UseEnvironment(System.Environment.GetEnvironmentVariable("DESKTOP_ENVIRONMENT") ?? "Production");

            builder.ConfigureAppConfiguration((hostContext, configBuilder) =>
            {
                configBuilder.AddJsonFile("appsettings.json");
                configBuilder.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
            });

            builder.ConfigureServices((hostContext, services) =>
            {
                services.AddOptions();

                services.AddFrontend();
                services.AddBackendBusiness();
                services.AddBackendData();

                services.AddDbContextFactory<ContextoSqlServer>(options =>
                {
                    options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(ContextoSqlServer)));
                });
                services.AddScoped(p => p.GetRequiredService<IDbContextFactory<ContextoSqlServer>>().CreateDbContext());

            });
            var app = builder.Build();

            app.Services.GetRequiredService<MainWindow>().Show();
        }
    }
}
