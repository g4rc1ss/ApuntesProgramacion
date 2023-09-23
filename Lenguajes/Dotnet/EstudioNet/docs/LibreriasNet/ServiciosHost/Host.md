# Host Generico
El host es un objeto que encapsula todos los recursos de la aplicación, como:
- Inyección de dependencias (ID)
- Registro (logging)
- Configuración
- Implementaciones de IHostedService

Cuando se inicia un host, se ejecuta el metodo `StartAsync` de los servicios registrados `IHostedService`.

La razón principal para incluir todos los recursos de la aplicación en un objeto es la administración de la duración: el control sobre el inicio de la aplicación y el apagado estable.

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
1. **CreateDefaultBuilder**: Nos crea un objeto `IHostBuilder` con una configuracion por defecto como la variable de entorno, lectura de los archivos de configuracion(**appsettings**), etc.
1. **ConfigureLogging** Metodo para indicar el funcionamiento del logging, como el proveedor, la forma de tratar los logs, etc.
1. **ConfigureAppConfiguration**: Agrega los parametros de configuracion de la aplicacion.
1. **ConfigureServices**: Agrega servicios al contenedor de dependencias
1. Creamos el objeto `IHost` para poder ejecutar la aplicacion.


# Host Web
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