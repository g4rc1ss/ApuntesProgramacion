# Eventos
Un evento es un mensaje que envía un objeto cuando ocurre una acción.

Los eventos se realizan a mano en el codigo y son contenedores de un metodo Delegado que es el que se va a invocar.

Por ejemplo al interactuar con una interfaz de escritorio, como WPF, se crea un objeto Button y se agrega al evento `Click` el metodo que se ha de ejecutar `Button_Click(object sender, RoutedEventArgs e)`  
Por debajo lo que hace el codigo es detectar cuando se pulsa el boton y entonces, invoca el evento el cual tiene agregar como delegado el metodo que hemos escrito.

Para crear y controlar un evento se realiza el siguiente codigo:

```Csharp
public static event EventHandler ExportEvent;

public static void ExportEventCaller(ExportObject export)
{
    // El constructor de EventHandler recibe dos objetos, un object y un EventArgs
    ExportEvent?.Invoke(export, null);
}


ExportAPI.ExportEvent += LoadEventCall;
// LoadEventCall es el metodo que se va a ejecutar
```
