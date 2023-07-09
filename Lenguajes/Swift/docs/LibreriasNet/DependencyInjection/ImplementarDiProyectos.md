# Implementar DI en proyectos
Para implementar solamente la Inyeccion de dependencias se podra usar el siguiente codigo.

1. Instanciamos una clase del tipo `ServiceCollection`
1. Agregamos las dependencias que necesitamos a la coleccion.
1. Compilamos la coleccion para poder hacer uso de esas dependencias y obtenermos el `ServiceProvider`
```Csharp
var serviceCollection = new ServiceCollection();
serviceCollection.AddTransient<Interface, Clase>();
var provider = serviceCollection.BuildServiceProvider();
```

La inyeccion de dependencias se puede implementar en todos los tipos de proyectos actuales de .Net

## Host Generico
El host es un objeto que encapsula todos los recursos de la aplicación, como:
- Inserción de dependencias (ID)
- Registro (logging)
- Configuración
- Implementaciones de IHostedService

Cuando se inicia un host, se ejecuta el metodo `StartAsync` de los servicios registrados `IHostedService`.

La razón principal para incluir todos los recursos interdependientes de la aplicación en un objeto es la administración de la duración: el control sobre el inicio de la aplicación y el apagado estable.

1. `CreateDefaultBuilder`: Nos crea un objeto `IHostBuilder` con una configuracion por defecto como la variable de entorno, lectura de los archivos de configuracion(**appsettings**), etc.
1. **ConfigureLogging** Metodo para indicar el funcionamiento del logging, como el proveedor, la forma de tratar los logs, etc.
1. **ConfigureAppConfiguration**: Agrega los parametros de configuracion de la aplicacion.
1. **ConfigureServices**: Agrega servicios al contenedor de dependencias
1. Creamos el objeto `IHost` para poder ejecutar la aplicacion.
```Csharp
var builder = Host.CreateDefaultBuilder(e.Args);

builder.ConfigureLogging((hostContext, log) =>
{
    log.AddConsole();
});

builder.ConfigureAppConfiguration((hostContext, configBuilder) =>
{
    config.AddUserSecrets(Assembly.GetExecutingAssembly());
});

builder.ConfigureServices((hostContext, services) =>
{
    services.AddTransient<IClass1, Class1>();
});
var app = builder.Build();
```

## Host Web
Este tipo de host es igual al de arriba, la unica diferencia es que cuando se ejecute el metodo `RunAsync()` sera capaz de procesar peticiones **http**.

> Con este ejemplo podemos ejecutar un api web, por ejemplo, en una aplicación desktop
```Csharp
var builder = WebApplication.CreateBuilder();

builder.Host.AddLoggerConfiguration();

builder.Services.AddTransient<IClass1, Class1>();

builder.Services.AddControllers()
    // Referenciamos a un assembly en el caso de que tengamos Controllers en otro proyecto
    .AddApplicationPart(typeof(WebApiServicesExtension).Assembly);

var app = builder.Build();
//app.Urls.Add("http://localhost:5001");

app.MapControllers();

await app.RunAsync("http://localhost:5000");
```
