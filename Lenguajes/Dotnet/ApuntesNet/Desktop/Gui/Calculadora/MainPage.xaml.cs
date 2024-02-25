namespace Calculadora;

public partial class MainPage : ContentPage
{
    private string operacion = "";
    private readonly int[] _numero = new int[2];
    private bool insertar = true;
    private bool operacionSeleccion = false;

    public MainPage()
    {
        InitializeComponent();
    }

    private async void Listener(object sender, EventArgs e)
    {
        var compo = (Componente)sender;
        var respuesta = compo.Accion(mostrar);

        if (ComprobarNumero(respuesta))
        {
            if (insertar)
            {
                _numero[0] = int.Parse(mostrar.Text);
            }
            else if (!insertar)
            {
                _numero[1] = int.Parse(mostrar.Text);
            }
        }
        else if (respuesta.Equals("+") || respuesta.Equals("-") || respuesta.Equals("*") || respuesta.Equals("/"))
        {
            if (mostrar.Text.Equals(""))
            {
                await DisplayAlert("Calculadora", "Calculadora", "Debes introducir un numero primero", "Cancel");
                return;
            }
            if (operacionSeleccion)
            {
                await DisplayAlert("Calculadora", "Calculadora", "Ya has seleccionado una operacion", "Cancel");
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
            for (var x = 0; x < _numero.Length; x++)
            {
                _numero[x] = 0;
            }

            insertar = true;
            operacionSeleccion = false;
        }
        else if (respuesta.Equals("="))
        {
            if (operacion == null)
            {
                await DisplayAlert("Calculadora", "Debes seleccionar una operacion primero", "Cancel");
                return;
            }
            if (mostrar.Text.Equals(""))
            {
                await DisplayAlert("Calculadora", "Debes introducir otro numero", "Cancel");
                return;
            }
            var resultado = Operar(operacion);
            mostrar.Text = "" + resultado;
            _numero[0] = resultado;
            insertar = true;
            operacionSeleccion = false;
        }
    }

    private int Operar(string operacion)
    {
        return operacion switch
        {
            "+" => _numero[0] + _numero[1],
            "-" => _numero[0] - _numero[1],
            "*" => _numero[0] * _numero[1],
            "/" => _numero[0] / _numero[1],
            _ => 0,
        };
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
