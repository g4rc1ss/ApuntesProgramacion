using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace TresEnRayaClase {

    public partial class MainWindow :Window {
        private bool turno;
        private readonly int[] partida = new int[9];
        private int victorias1 = 0, victorias2 = 0;
        private readonly List<Ellipse> circulos = new List<Ellipse>();
        private readonly List<Grid> aspas = new List<Grid>();
        public MainWindow() {
            InitializeComponent();
            CargarLista();
            Inicio();
        }

        private void CargarLista() {
            circulos.Add(C1); circulos.Add(C2); circulos.Add(C3); circulos.Add(C4); circulos.Add(C5); circulos.Add(C6); circulos.Add(C7); circulos.Add(C8); circulos.Add(C9);
            aspas.Add(X1); aspas.Add(X2); aspas.Add(X3); aspas.Add(X4); aspas.Add(X5); aspas.Add(X6); aspas.Add(X7); aspas.Add(X8); aspas.Add(X9);
        }

        private void Inicio() {
            foreach (var circulo in circulos)
                circulo.Visibility = Visibility.Hidden;

            foreach (var aspa in aspas)
                aspa.Visibility = Visibility.Hidden;

            lblTurno.Content = "Jugador 1";
            turno = true;

            for (var i = 0; i < 9; i++)
                partida[i] = 0;
        }

        private void Tablero_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            var fuente = e.OriginalSource as FrameworkElement;
            switch (fuente.Name) {
                case "Rect1":
                Mostrar(1);
                //MessageBox.Show("0,0");
                break;
                case "Rect2":
                Mostrar(2);
                //MessageBox.Show("0,1");
                break;
                case "Rect3":
                Mostrar(3);
                // MessageBox.Show("0,2");
                break;
                case "Rect4":
                Mostrar(4);
                //MessageBox.Show("1,0");
                break;
                case "Rect5":
                Mostrar(5);
                //MessageBox.Show("1,1");
                break;
                case "Rect6":
                Mostrar(6);
                //MessageBox.Show("1,2");
                break;
                case "Rect7":
                Mostrar(7);
                //MessageBox.Show("2,0");
                break;
                case "Rect8":
                Mostrar(8);
                //MessageBox.Show("2,1");
                break;
                case "Rect9":
                Mostrar(9);
                //MessageBox.Show("2,2");
                break;
            }
        }

        private void Mostrar(int cuadradito) {

            if (partida[cuadradito - 1] != 0)
                return;

            if (turno) { // turno del jugador 1 
                partida[cuadradito - 1] = 1;
                aspas[cuadradito - 1].Visibility = Visibility.Visible;

            } else {//turno del jugador 2
                partida[cuadradito - 1] = 2;
                circulos[cuadradito - 1].Visibility = Visibility.Visible;
            }

            if (ComprobarFinal())
                return;
            if (turno)
                lblTurno.Content = "Jugador 2";
            else
                lblTurno.Content = "Jugador 1";
            turno = !turno;
        }

        private bool ComprobarFinal() {
            if ((partida[0] == 1 && partida[1] == 1 && partida[2] == 1) ||
                (partida[3] == 1 && partida[4] == 1 && partida[5] == 1) ||
                (partida[6] == 1 && partida[7] == 1 && partida[8] == 1) ||
                (partida[0] == 1 && partida[3] == 1 && partida[6] == 1) ||
                (partida[1] == 1 && partida[4] == 1 && partida[7] == 1) ||
                (partida[2] == 1 && partida[5] == 1 && partida[8] == 1) ||
                (partida[0] == 1 && partida[4] == 1 && partida[8] == 1) ||
                (partida[2] == 1 && partida[4] == 1 && partida[6] == 1)) {

                Victorias1.Content = ++victorias1;
                MessageBox.Show("Gana el jugador 1");
                Inicio();
                return true;
            }
            if ((partida[0] == 2 && partida[1] == 2 && partida[2] == 2) ||
                (partida[3] == 2 && partida[4] == 2 && partida[5] == 2) ||
                (partida[6] == 2 && partida[7] == 2 && partida[8] == 2) ||
                (partida[0] == 2 && partida[3] == 2 && partida[6] == 2) ||
                (partida[1] == 2 && partida[4] == 2 && partida[7] == 2) ||
                (partida[2] == 2 && partida[5] == 2 && partida[8] == 2) ||
                (partida[0] == 2 && partida[4] == 2 && partida[8] == 2) ||
                (partida[2] == 2 && partida[4] == 2 && partida[6] == 2)) {

                victorias2++;
                Victorias2.Content = victorias2;
                MessageBox.Show("Gana el jugador 2");
                Inicio();
                return true;
            }
            var final = true;
            for (var i = 0; i < 9 && final; i++)
                if (partida[i] == 0)
                    final = false;

            if (final) {
                MessageBox.Show("Gana el gato");
                Inicio();
                return true;
            }
            return false;
        }
    }
}
