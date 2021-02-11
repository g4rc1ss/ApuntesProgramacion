using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaloniaWPF {
    public class MainWindow :Window {
        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        public void BotonPrueba(object sender, RoutedEventArgs e) {
            this.Find<TextBlock>("PruebaText").Text = "Ahora Cambiamos el texto";
        }
    }
}
