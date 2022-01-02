using System.Windows;
using ConversorArchivos.WindowView;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConversorArchivos
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            _ = CreateHostBuilder(e.Args).Build().RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return new HostBuilder()
.ConfigureServices((hostContext, services) =>
{
    _ = services.AddOptions();

    _ = services.AddDependencyInyection();

    var presentation = services.BuildServiceProvider().GetRequiredService<MainWindow>();
    presentation.Show();
});
        }
    }
}
