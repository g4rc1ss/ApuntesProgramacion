using ConversorArchivos.Actions.Interfaces;
using System.Threading.Tasks;
using System.Windows;
using Winforms = System.Windows.Forms;

namespace ConversorArchivos.WindowView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IConvertirAction convertirAction;
        public MainWindow(IConvertirAction convertirAction)
        {
            this.convertirAction = convertirAction;
            InitializeComponent();
        }

        private void Buscar(object sender, RoutedEventArgs e)
        {
            Winforms.FolderBrowserDialog ruta = new();
            if (ruta.ShowDialog() != Winforms::DialogResult.OK)
            {
                MessageBox.Show("No se ha podido obtener la ruta correctamente", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            RutaCarpetaArchivosConvertir.Text = ruta.SelectedPath;

        }

        private async void Empezar(object sender, RoutedEventArgs e)
        {
            await convertirAction.ConvertTo(RutaCarpetaArchivosConvertir.Text, "pdf", "md");

            MessageBox.Show("Conversion terminada");
        }
    }
}
