using AplicacionToExtender.Database;
using System.Windows;

namespace AplicacionToExtender {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App :Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            using (var context = new PluginsContext()) {
                context.Database.EnsureCreated();
            }
        }
    }
}
