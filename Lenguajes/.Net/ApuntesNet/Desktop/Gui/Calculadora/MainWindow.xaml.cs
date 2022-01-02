using System;
using System.Windows;
using CalculadoraComponente;

namespace Calculadora
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string operacion = "";
        private readonly int[] numero = new int[2];
        private bool insertar = true;
        private bool operacionSeleccion = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Listener(object sender, RoutedEventArgs e)
        {
            Lanzar(sender);
        }

        public void Lanzar(object sender)
        {
            var compo = (Componente)sender;
            var respuesta = compo.Accion(mostrar);

            if (ComprobarNumero(respuesta))
            {
                if (insertar)
                {
                    numero[0] = int.Parse(mostrar.Text);
                }
                else if (!insertar)
                {
                    numero[1] = int.Parse(mostrar.Text);
                }
            }
            else if (respuesta.Equals("+") || respuesta.Equals("-") || respuesta.Equals("*") || respuesta.Equals("/"))
            {
                if (mostrar.Text.Equals(""))
                {
                    MessageBox.Show("Debes introducir un numero primero");
                    return;
                }
                if (operacionSeleccion)
                {
                    MessageBox.Show("Ya has seleccionado una operacion");
                    return;
                }
                else
                {
                    mostrar.Text = "";
                    operacion = respuesta;
                    insertar = false;
                    operacionSeleccion = true;
                }

            }
            else if (respuesta.Equals("C"))
            {
                for (var x = 0; x < numero.Length; x++)
                {
                    numero[x] = 0;
                }

                insertar = true;
                operacionSeleccion = false;
            }
            else if (respuesta.Equals("="))
            {
                if (operacion == null)
                {
                    MessageBox.Show("Debes seleccionar una operacion primero");
                    return;
                }
                if (mostrar.Text.Equals(""))
                {
                    MessageBox.Show("Debes introducir otro numero");
                    return;
                }
                var resultado = Operar(operacion);
                mostrar.Text = "" + resultado;
                numero[0] = resultado;
                insertar = true;
                operacionSeleccion = false;
            }
        }

        private int Operar(string operacion)
        {
            switch (operacion)
            {
                case "+":
                    return numero[0] + numero[1];
                case "-":
                    return numero[0] - numero[1];
                case "*":
                    return numero[0] * numero[1];
                case "/":
                    return numero[0] / numero[1];
            }
            return 0;
        }

        private bool ComprobarNumero(string respuesta)
        {
            try
            {
                int.Parse(respuesta);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
