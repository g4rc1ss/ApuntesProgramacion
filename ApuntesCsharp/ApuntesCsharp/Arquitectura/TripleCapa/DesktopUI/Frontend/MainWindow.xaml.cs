using System.Windows;
using Backend.Business.Actions;
using Backend.Business.DataAccessObject;

namespace Frontend {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private readonly UserAction userAction;

        public MainWindow(UserAction userAction) {
            InitializeComponent();
            this.userAction = userAction;
        }

        private async void CargarBBDD(object sender, RoutedEventArgs e) {
            var respUsuarios = await userAction.GetAllUsers();
            if (respUsuarios.Count <= 0) {
                _ = MessageBox.Show("No se han obtenido resultados", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            foreach (var users in respUsuarios) {
                _ = DataGrid_Table.Items.Add(new User() {
                    Name = users.Nombre,
                    Edad = users.Edad
                });
            }
            DataGrid_Table.Items.Refresh();
        }
    }
}
