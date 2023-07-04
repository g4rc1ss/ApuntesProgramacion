using System.ComponentModel;

namespace Calculadora;

public class Componente : Button
{

    public Componente()
    {
    }

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
            cajaDeTexto.Text += Text.ToString();
            return cajaDeTexto.Text;
        }
        else if (Tipo == 2)
        {//Operacion
            return Text.ToString();
        }
        else if (Tipo == 3)
        {//Vaciar
            cajaDeTexto.Text = "";
            return cajaDeTexto.Text;
        }
        return null;
    }
}
