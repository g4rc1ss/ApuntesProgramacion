
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace _1erEjecicio
{
    /// <summary>
    /// Interaction logic for WindowWrap.xaml
    /// </summary>
    public partial class WindowWrap : Window
    {
        public WindowWrap()
        {
            InitializeComponent();
        }

        private void BtnHorizontal_Click(object sender, RoutedEventArgs e)
        {
            panelWrap.Orientation = Orientation.Horizontal;
        }

        private void BtnVertical_Click(object sender, RoutedEventArgs e)
        {
            panelWrap.Orientation = Orientation.Vertical;
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            var result = openFileDialog1.ShowDialog();
            if (result.Value)
            {
                var nombreFichero = openFileDialog1.FileName;
                MessageBox.Show("Has intentado abrir el fichero " + nombreFichero);
            }

        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog();
            var result = saveFileDialog1.ShowDialog();
            if (result.Value)
            {
                var nombreFichero = saveFileDialog1.FileName;
                MessageBox.Show("Has intentado guardar el fichero " + nombreFichero);
            }
        }
    }
}
