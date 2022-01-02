using System.Windows;
using System.Windows.Input;

namespace _1erEjecicio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowWrap ventanaWrap;
        private WindowStack ventanaStack;
        private WindowDock ventanaDock;
        private WindowCanvas ventanaCambas;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var frameW = e.OriginalSource as FrameworkElement;
            switch (frameW.Name)
            {
                case "circuloAzul":
                    MessageBox.Show("has pulsado sobre el circulo azul");
                    break;
                case "circuloRojo":
                    MessageBox.Show("has pulsado sobre el circulo rojo");
                    break;
                case "circuloAmarillo":
                    MessageBox.Show("has pulsado sobre el circulo amarillo");
                    break;
                default:
                    MessageBox.Show("has pulsado sobre el grid");
                    break;
            }
        }

        public void BotonWrap_Click(object sender, RoutedEventArgs e)
        {
            if (ventanaWrap == null || !ventanaWrap.IsLoaded)
            {
                ventanaWrap = new WindowWrap();
            }

            if (ventanaWrap != null && !ventanaWrap.IsVisible)
            {
                ventanaWrap.Show();
            }
        }

        private void BotonStack_Click(object sender, RoutedEventArgs e)
        {
            if (ventanaStack == null || !ventanaStack.IsLoaded)
            {
                ventanaStack = new WindowStack();
            }

            if (ventanaStack != null && !ventanaStack.IsVisible)
            {
                ventanaStack.Show();
            }
        }

        private void BotonDock_Click(object sender, RoutedEventArgs e)
        {
            if (ventanaDock == null || !ventanaDock.IsLoaded)
            {
                ventanaDock = new WindowDock();
            }

            if (ventanaDock != null && !ventanaDock.IsVisible)
            {
                ventanaDock.Show();
            }
        }

        private void BotonCanvas_Click(object sender, RoutedEventArgs e)
        {
            if (ventanaCambas == null || !ventanaCambas.IsLoaded)
            {
                ventanaCambas = new WindowCanvas();
            }

            if (ventanaCambas != null && !ventanaCambas.IsVisible)
            {
                ventanaCambas.Show();
            }
        }
    }
}
