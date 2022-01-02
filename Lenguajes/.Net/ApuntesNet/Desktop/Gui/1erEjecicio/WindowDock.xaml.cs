using System.Windows;
using System.Windows.Controls;

namespace _1erEjecicio
{
    /// <summary>
    /// Interaction logic for WindowDock.xaml
    /// </summary>
    public partial class WindowDock : Window
    {
        public WindowDock()
        {
            InitializeComponent();
        }

        private void BtnDock_Click(object sender, RoutedEventArgs e)
        {
            switch (btnDock.Content.ToString())
            {
                case "Menu Arriba":
                    DockPanel.SetDock(btnDock, Dock.Top);
                    btnDock.Content = "Menu Dcha";
                    break;
                case "Menu Dcha":
                    DockPanel.SetDock(btnDock, Dock.Right);
                    btnDock.Content = "Menu Abajo";
                    break;
                case "Menu Abajo":
                    DockPanel.SetDock(btnDock, Dock.Bottom);
                    btnDock.Content = "Menu Izda";
                    break;
                case "Menu Izda":
                    DockPanel.SetDock(btnDock, Dock.Left);
                    btnDock.Content = "Menu Arriba";
                    break;
            }

        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            var rsltMessageBox = MessageBox.Show("¿Quieres cerrar la ventana?", "Cerrar", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (rsltMessageBox == MessageBoxResult.Yes)
            {
                Close();
            }
        }
    }
}
