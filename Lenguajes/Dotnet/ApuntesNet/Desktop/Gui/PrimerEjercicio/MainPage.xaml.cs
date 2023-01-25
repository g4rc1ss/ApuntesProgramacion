using PrimerEjercicio.Windows;

namespace PrimerEjercicio;

public partial class MainPage : ContentPage
{
    private readonly WindowWrap _ventanaWrap;
    private readonly WindowStack _ventanaStack;

    public MainPage(WindowWrap ventanaWrap, WindowStack ventanaStack)
    {
        InitializeComponent();
        _ventanaWrap = ventanaWrap;
        _ventanaStack = ventanaStack;
    }

    void BotonWrap_Click(System.Object sender, System.EventArgs e)
    {
        Application.Current.OpenWindow(new Window(_ventanaWrap));
    }

    async void Grid_MouseLeftButtonUp(object sender, FocusEventArgs e)
    {
        return;
        //switch ()
        //{
        //    case "circuloAzul":
        //        await DisplayAlert("title", "has pulsado sobre el circulo azul", "Cancel");
        //        break;
        //    case "circuloRojo":
        //        await DisplayAlert("title", "has pulsado sobre el circulo rojo", "Cancel");
        //        break;
        //    case "circuloAmarillo":
        //        await DisplayAlert("title", "has pulsado sobre el circulo amarillo", "Cancel");
        //        break;
        //    default:
        //        await DisplayAlert("title", "has pulsado sobre el grid", "Cancel");
        //        break;
        //}
    }

    void BotonStack_Click(System.Object sender, System.EventArgs e)
    {
        Application.Current.OpenWindow(new Window
        {
            Page = _ventanaStack,
        });
    }
}


