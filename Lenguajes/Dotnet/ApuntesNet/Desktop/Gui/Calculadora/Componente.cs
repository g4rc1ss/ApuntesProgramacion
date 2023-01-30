using System.ComponentModel;

namespace Calculadora;

public class Componente : Button
{

    public Componente()
    {
        WidthRequest = 30;
        HeightRequest = 30;
    }

    private string texto;

    [Category("Opcion")]
    public int Tipo { set; get; }

    public string Accion(Editor cajaDeTexto)
    {
        if (Tipo == 0)
        {
            return null;
        }
        else if (Tipo == 1)
        {//Numeros
            texto += Text.ToString();
            cajaDeTexto.Text += texto.ToString();
            return texto;
        }
        else if (Tipo == 2)
        {//Operacion
            return Text.ToString();
        }
        else if (Tipo == 3)
        {//Vaciar
            cajaDeTexto.Text = "";
            return Text.ToString();
        }
        return null;
    }
}
