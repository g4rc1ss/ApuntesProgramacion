# Open/Closed Principle
Traduccion **Principio de Abierto Cerrado**

Este principio indica que "Una clase debe de estar abierta para extension y cerrada para modificacion".

Una vez una clase ya ha sido implementada y esta en funcionamiento, este principio indica que no se debe de modificar.

> Una excepcion es, por ejemplo, un bug.  
Si se reporta un bug y se encuentra localizado en una clase, puede ser modificada.

Muchas veces, tenemos una clase que esta siendo utilizada en diferentes proyectos de codigo y para uno de esos proyectos, requerimos de agregarle una funcionalidad. El  problema de eso, es que por culpa de 1 cosa, puede que afectes al resto y eso es lo que se quiere evitar.

Necesitamos encontrar una forma de extender esas funcionalidades

## Uso de herencia
La primera de las formas de conseguir esto sobreescribir metodos mediante el uso de herencia

Al añadir la palabra clave `virtual` hemos modificado esta clase para ser abierta para extender.

En caso de que no quieras extender la clase NO debes añadir la palabra clave `virtual`. Si ha de ser extendida ya se cambiará si hiciera falta en el futuro.

Por ejemplo, queremos cambiar nuestro sistema de logs en cierta parte crítica de nuestra apliación, para que además de loguear el error en un fichero de log, lo almacene en una base de datos. 

Para este escenario NO debemos modificar el sistema actual ya que ya esta en produccion. entonces lo que podemos hacer es basándonos en Logging crear una clase nueva:
```Csharp
public class DatabaseLogger : Logging
{
    private LogRepository logRepo { get; set; }
    public DatabaseLogger()
    {
        logRepo = new LogRepository();
    }

    public override void Fatal(string message, Exception e)
    {
        logRepo.AlmacenarError(message, e);
        base.Fatal(message, e);
    }
}
```

## Uso de Patron Composite
La forma más recomendable y que suele dar lugar a menos errores es utilizar un patrón composite, el cual nos permite cambiar el funcionamiento en tiempo de ejecución.

1. Declaramos la interface `ILogger` con los metodos a implementar.
1. Tenemos la clase que queremos extender, que en este caso es `Logging`
1. Cremaos la clase nueva añadiendo la funcionalidad que necesitamos, en este caso la clase `DatabaseLogger`.
```Csharp
public interface ILogger
{
    void Info(string message);
    void Error(string message, Exception e);
    void Fatal(string message, Exception e);
}

public class Logging : ILogger
{
    //Resto del codigo
}

public class DatabaseLogger  : ILogger
{
    //Resto del código
}
```
Cabe destacar que para que esto funcione, nuestro codigo deberia de recibir la interface y no la clase como tal.

De esta forma, en la clase donde necesitamos esta extension, recibiremos la interfaz y la implementacion se hará en el paso anterior o en la inyeccion de  dependencias.