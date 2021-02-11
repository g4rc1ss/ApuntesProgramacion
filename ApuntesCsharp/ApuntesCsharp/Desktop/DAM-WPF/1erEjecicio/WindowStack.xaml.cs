using System.Windows;
using System.Windows.Controls;

namespace _1erEjecicio {
    /// <summary>
    /// Interaction logic for WindowStack.xaml
    /// </summary>
    public partial class WindowStack :Window {
        public WindowStack() {
            InitializeComponent();
        }

        private void BtnVertical_Click(object sender, RoutedEventArgs e) {
            if (panelStack.Orientation != Orientation.Vertical)
                panelStack.Orientation = Orientation.Vertical;
        }

        private void BtnHorizontal_Click(object sender, RoutedEventArgs e) {
            if (panelStack.Orientation != Orientation.Horizontal)
                panelStack.Orientation = Orientation.Horizontal;
        }

        private void BtnSeparar_Click(object sender, RoutedEventArgs e) {
            if (btnSeparar.Content.ToString() == "Separar") {
                btnVertical.Margin = new Thickness(5, 10, 5, 10);
                btnHorizontal.Margin = new Thickness(5, 10, 5, 10);
                btnSeparar.Margin = new Thickness(5, 10, 5, 10);
                btnSeparar.Content = "Unir";
            } else {
                btnVertical.Margin = new Thickness(0, 0, 0, 0);
                btnHorizontal.Margin = new Thickness(0, 0, 0, 0);
                btnSeparar.Margin = new Thickness(0, 0, 0, 0);
                btnSeparar.Content = "Separar";
            }
        }
    }
}
