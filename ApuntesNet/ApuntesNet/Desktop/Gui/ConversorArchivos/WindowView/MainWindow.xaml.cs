using System.Collections.Generic;
using System.IO;
using System.Windows;
using Aspose.Words;
using ConversorArchivos.Actions.Interfaces;
using Winforms = System.Windows.Forms;

namespace ConversorArchivos.WindowView {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly List<string> extensiones = new() {
            "pdf",
            "doc",
            "docx",
            "md",
            "txt"
        };
        private readonly IConvertirAction convertirAction;
        public MainWindow(IConvertirAction convertirAction) {
            this.convertirAction = convertirAction;
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar() {
            foreach (var extension in extensiones) {
                ExtensionesA.Items.Add(extension);
                ExtensionesDe.Items.Add(extension);
            }
        }

        private void Buscar(object sender, RoutedEventArgs e) {
            Winforms.FolderBrowserDialog ruta = new();
            if (ruta.ShowDialog() != Winforms::DialogResult.OK) {
                MessageBox.Show("No se ha podido obtener la ruta correctamente", "", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            RutaCarpetaArchivosConvertir.Text = ruta.SelectedPath;

        }

        private async void Empezar(object sender, RoutedEventArgs e) {
            await convertirAction.ConvertTo(RutaCarpetaArchivosConvertir.Text, ExtensionesDe.SelectedItem.ToString(), ExtensionesA.SelectedItem.ToString());

            MessageBox.Show("Conversion terminada");
        }
    }
}
