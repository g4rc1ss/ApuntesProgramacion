using Apuntes.BackLocal.Core.Actions;
using Apuntes.BackLocal.Core.DataAccessObject;
using System.Windows;

namespace Apuntes.WPF.Presentacion {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window {
        private readonly UserAction userAction;

        public MainWindow(UserAction userAction) {
            InitializeComponent();
            this.userAction = userAction;
        }

        private async void CargarBBDD(object sender, RoutedEventArgs e) {
            var respUsuarios = await userAction.GetAllUsers();
            if (respUsuarios.Resultado != respUsuarios.OK) {
                MessageBox.Show(respUsuarios.Mensaje, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            foreach (var users in respUsuarios.Datos) {
                DataGrid_Table.Items.Add(new User() {
                    Name = users.Nombre,
                    Edad = users.Edad
                });
            }
            DataGrid_Table.Items.Refresh();
        }
    }
}
