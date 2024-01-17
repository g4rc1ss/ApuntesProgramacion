# ILogger
Una interfaz genérica creada por Microsoft y agregada por defecto en la mayoria de paquetes a traves de DI

Esta interfaz es un `contrato` para unificar el sistema de logs de todos los diferentes proveedores que hay y poder tener una abstraccion completa de esos frameworks, de forma que si mas adeltante queremos modificar el lugar de almacenamiento, por ejemplo, tenemos los logs configurados a un fichero de texto y queremos empezar a guardarlos a una base de datos como `MSSQL Server` o un proveedor como `SEQ` o `Grafana Loki`. La idea es que solo tengamos que modificar el proveedor, pero nada de la implementacion a nivel de código.


## Niveles de Registro
| LogLevel | Valor | Método | Descripción |
| -------- | ----- | ------ | ----------- |
|Trace	0	LogTrace	Contienen los mensajes más detallados. Estos mensajes pueden contener datos confidenciales de la aplicación. Están deshabilitados de forma predeterminada y no se deben habilitar en un entorno de producción.
| Debug | 1 | LogDebug | Para depuración y desarrollo. Debido al elevado volumen, tenga precaución cuando lo use en producción.
| Information | 2 | LogInformation | Realiza el seguimiento del flujo general de la aplicación. Puede tener un valor a largo plazo.
| Warning | 3 | LogWarning | Para eventos anómalos o inesperados. Normalmente incluye errores o estados que no provocan un error en la aplicación.
| Error | 4 | LogError | Para los errores y excepciones que no se pueden controlar. Estos mensajes indican un error en la operación o solicitud actual, no un error de toda la aplicación.
| Critical | 5 | LogCritical | Para los errores que requieren atención inmediata. Ejemplos: escenarios de pérdida de datos, espacio en disco insuficiente.
| None | 6 | | Especifica que una categoría de registro no debe escribir mensajes.

## Identificacion de eventos
`ILogger` puede almacenar un `EventId` que podemos pasarle, de esta forma, podemos almacenar y buscar por el id del evento o identificar mejor por donde ha ido nuestro codigo:

```Csharp
public class MyLogEvents
{
    public const int GenerateItems = 1000;
}
```

```Csharp

public void RegistrandoEvento()
{
    _logger.LogInformation(MyLogEvents.GenerateItems, "Generando Items");
}
```

## Plantillas y parametrizar mensajes y objetos
`ILogger` acepta un mensaje solamente de tipo `string` y por tanto, tienes varias opciones para poder enviar objetos al proveedor de log.

### Template con objetos simples
Para añadir objetos simples(`int`, `string`, etc.), objetos que solo vayan a tener 1 valor, simplemente podemos pasarlos como parametro

```Csharp
_logger.LogInformation("Getting item {Id}", id);
```

Cuando enviamos varios parametros, hay que tener en cuenta el orden de estos, pues que se asignan en orden, no por nombre
```Csharp
var apples = 1;
var pears = 2;
var bananas = 3;
_logger.LogInformation("Parameters: {apples}, {pears}, {bananas}", apples, pears, bananas);
```
El nombre que indicamos en la opcion parametrizada del mensaje "`{apples}`" es importante, puesto que el mensaje final va a ser parecido a "apples : 1", si lo llamamos "objeto1", el nombre seria "objeto1: 1" y no entenderiamos a que se refiere


### Template con objetos complejos
A veces necesitamos logear objetos que tienen diferentes valores dentro, por ejemplo, un objeto `User`, tendra las propiedades `Name`, `Email`, etc.

En vez de tener que andar serializando en JSON o similares, podemos agregar un `@` cuando especificamos el nombre del campo.

```Csharp
var user = new User("Nombre", "Email@email.com");
_logger.LogInformation("Se ha creado el usuario: {@DatosCreacionUsuario}", user);
```
Esto, en el mensaje final, se ve como crea el parametro `DatosCreacionUsuario`, que contiene el objeto `user` y por tanto, a la hora de filtrar por los logs, podremos filtrar por los campos de este.

> Esta es la forma recomendada de tratar los mensajes, puesto que en un proveedor de lectura de logs como `seq`, registrara la existencia del campo `DatosCreacionUsuario` o de los campos `Id`, `apples`, etc. y podremos filtrar por ellos de forma sencilla con su sintaxis de consulta, por ejemplo, para filtrar los de datos de usuario, podremos poner algo del estilo. `DatosCreacionUsuario.Nombre = "Nombre" and DatosCreacionUsuario.Email = "Email@email.com"`

> Si lo creamos en un sistema como SQL Server, habra una columna de `Properties` en `XML` donde podremos filtrar de igual forma, adaptandose dicha implementacion a los diferentes proveedores de registros que implementemos

