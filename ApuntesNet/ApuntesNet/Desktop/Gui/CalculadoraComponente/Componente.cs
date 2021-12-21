using System.ComponentModel;

namespace CalculadoraComponente
{
    public class Componente : System.Windows.Controls.Button
    {

        public Componente()
        {
            Width = 30;
            Height = 30;
        }

        private string texto;

        [Category("Opcion")]
        public int Tipo { set; get; }

        public string Accion(System.Windows.Controls.TextBox cajaDeTexto)
        {
            if (Tipo == 0)
            {
                return null;
            }
            else if (Tipo == 1)
            {//Numeros
                texto += Content.ToString();
                cajaDeTexto.Text += Content.ToString();
                return texto;
            }
            else if (Tipo == 2)
            {//Operacion
                return Content.ToString();
            }
            else if (Tipo == 3)
            {//Vaciar
                cajaDeTexto.Text = "";
                return Content.ToString();
            }
            return null;
        }
    }
}
