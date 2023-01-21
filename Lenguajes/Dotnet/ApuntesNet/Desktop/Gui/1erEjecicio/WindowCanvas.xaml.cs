using System.Windows;
using System.Windows.Controls;

namespace _1erEjecicio
{
    /// <summary>
    /// Interaction logic for WindowCanvas.xaml
    /// </summary>
    public partial class WindowCanvas : Window
    {
        public WindowCanvas()
        {
            InitializeComponent();
        }

        private void BtnInicial_Click(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(btnArriba, 106);
            Canvas.SetTop(btnArriba, 31);
            Canvas.SetLeft(btnDerecha, 206);
            Canvas.SetTop(btnDerecha, 131);
            Canvas.SetLeft(btnAbajo, 106);
            Canvas.SetTop(btnAbajo, 200);
            Canvas.SetLeft(btnIzquierda, 20);
            Canvas.SetTop(btnIzquierda, 131);
            Canvas.SetLeft(btnInicial, 106);
            Canvas.SetTop(btnInicial, 111);
        }

        private void BtnArriba_Click(object sender, RoutedEventArgs e)
        {

            //Canvas.SetLeft(btnDerecha, Canvas.GetLeft(btnDerecha);
            Canvas.SetTop(btnDerecha, Canvas.GetTop(btnDerecha) - 1);
            //  Canvas.SetLeft(btnAbajo, 106);
            Canvas.SetTop(btnAbajo, Canvas.GetTop(btnAbajo) - 1);
            // Canvas.SetLeft(btnIzquierda, 20);
            Canvas.SetTop(btnIzquierda, Canvas.GetTop(btnIzquierda) - 1);
            // Canvas.SetLeft(btnInicial, 106);
            Canvas.SetTop(btnInicial, Canvas.GetTop(btnInicial) - 1);
        }

        private void BtnAbajo_Click(object sender, RoutedEventArgs e)
        {
            Canvas.SetTop(btnDerecha, Canvas.GetTop(btnDerecha) + 1);
            Canvas.SetTop(btnArriba, Canvas.GetTop(btnArriba) + 1);
            Canvas.SetTop(btnIzquierda, Canvas.GetTop(btnIzquierda) + 1);
            Canvas.SetTop(btnInicial, Canvas.GetTop(btnInicial) + 1);
        }

        private void BtnIzquierda_Click(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(btnDerecha, Canvas.GetLeft(btnDerecha) - 1);
            Canvas.SetLeft(btnArriba, Canvas.GetLeft(btnArriba) - 1);
            Canvas.SetLeft(btnAbajo, Canvas.GetLeft(btnAbajo) - 1);
            Canvas.SetLeft(btnInicial, Canvas.GetLeft(btnInicial) - 1);
        }

        private void BtnDerecha_Click(object sender, RoutedEventArgs e)
        {
            Canvas.SetLeft(btnIzquierda, Canvas.GetLeft(btnIzquierda) + 1);
            Canvas.SetLeft(btnArriba, Canvas.GetLeft(btnArriba) + 1);
            Canvas.SetLeft(btnAbajo, Canvas.GetLeft(btnAbajo) + 1);
            Canvas.SetLeft(btnInicial, Canvas.GetLeft(btnInicial) + 1);
        }
    }
}
