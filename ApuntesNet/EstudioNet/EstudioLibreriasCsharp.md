# DependencyInjection
La inversión de dependencias es un principio que describe un conjunto de técnicas destinadas a disminuir el acoplamiento entre los componentes de una aplicación. Es uno de los principios SOLID más populares y utilizados en la creación de aplicaciones, frameworks y componentes por las ventajas que aporta a las mismas.

La inversión de dependencias suele también conocerse como inversión de control. En inglés, los términos más frecuentemente utilizados son "dependency inversion", abreviado como "DI", e "inversion of control" o simplemente "IoC".

Muy resumidamente, el Principio de Inversión de Dependencias propone evitar las dependencias rígidas entre componentes mediante las siguientes técnicas:

- Utilizar abstracciones (interfaces) en lugar de referencias directas entre clases, lo que facilita que podamos reemplazar componentes con suma facilidad.
- Hacer que una clase reciba referencias a los componentes que necesite para funcionar, en lugar de permitir que sea ella misma quien los instancie de forma directa o a través de factorías.

## Tipos de DI

A la hora de registrar la dependencia, tenemos 3 opciones que difieren en el **tiempo de vida**.

El contenedor mantiene todos los servicios que crea y una vez su tiempo de vida (lifetime) termina, son disposed o liberados para el garbage collector.

Es importante elegir el tipo de tiempo de vida correctamente, ya que no todos nos darán los mismos resultados.

- **Transient**: Se va a crear una instancia cada vez que se resuelva la dependencia.  
En otras palabras, cada vez que utilicemos un servicio “Transient” este será una nueva instancia.
    - Utilizamos Transient cuando el servicio contiene estado que puede cambiar (es mutable)  y no es thread-safe. Ya que cada servicio va a recibir su propia instancia, podemos consumir los métodos sin preocuparnos por si otros servicios están accediendo.
    - Por contra debemos gastar más memoria ya que necesitaremos más objetos y será algo más ineficiente.
    - Es muy común utilizar servicios transient cuando no tenemos claro qué opción utilizar. 

- **Scoped**: Si creamos un servicio que está registrado como scoped este vivirá por el tiempo de vida que exista ese scope.  
    - En `ASP.NET Core` la aplicación crea un scope para cada request que recibe, por tanto, se creara un scope cada vez que la aplicacion reciba una peticion.  
    Lo que quiere decir, que todos los servicios que se utilicen a traves de esa Request que necesiten resolver la dependencia Scope, usaran la misma.

- **Singleton**: La dependencia se va a resolver una sola vez en todo el codigo y a partir de ahí, cada vez que se solicite, se va a reutilizar dicha dependencia.
    - Si el servicio se utiliza muy frecuentemente puede proveer mejora en el rendimiento ya que se instancia una vez para la aplicación entera y no uno por servicio como `Transient`. 
    - Si utilizamos singleton debemos crear la clase a la que referencia o bien completamente inmutable ya que al ser la misma instancia en caso de ser mutable podría dar errores inesperados.
    - Utilizar técnicas donde nos aseguramos que la aplicación va a ser thread-safe. Un ejemplo muy común de singleton es caché en memoria.

Cuando programamos, definir que tipo de `lifetime` vamos a dar a nuestros servicios es importante, pero no solo eso, sino que debemos asegurarnos que nuestros servicios no dependen en otros servicios con tiempos de vida menores que ellos.

Y esto es debido a que así evitaremos errores o funcionamientos extraños durante el tiempo de ejecución.  
Si mi servicio `Scope` depende de un servicio `Transient`, puede que la dependencia transient, al tener un tiempo de vida menor, sea liberada y el scope pueda ver su proceso alterado o incluso saltar una excepcion.

## Formas de uso de DI
Despues de registrar el servicio que queremos implementar en la inyeccion de dependencias, requerimos de poder hacer uso de el en el resto del codigo.

Para esta finalidad hay varias formas de hacerlo.

### Por Constructor
Declaramos un constructor y recibimos como argumentos, las interfaces o las clases de los servicios que vamos a requerir para ese servicio, el inyector de dependencias se encargara de instanciar dichas dependencias

Este el metodo por defecto usado en la DI de .Net.

```Csharp
public class ClaseDI
{
    private readonly IUserAction _userAction;

    public ClaseDI(IUserAction userAction)
    {
        _userAction = userAction;
    }

    private async Task MetodoEjecutaDependencia()
    {
        var respUsuarios = await _userAction.GetAllUsers();
    }
}
```

### Por Atributo
Creamos las variables privadas de solo lectura y les ponemos el atributo `[Dependency]` para indicar al Inyector de Dependencias las instancias que debe de resolver.

Es un metodo menos común de uso, pero igualmente eficaz.

```Csharp
public class ClaseDI
{
    [Dependency]
    private readonly IUserAction _userAction;

    private async Task MetodoEjecutaDependencia()
    {
        var respUsuarios = await _userAction.GetAllUsers();
    }
}
```

### IServiceProvider
Otra forma de resolver dependencias es mediante el uso de `IServiceProvider`, Podemos recibir la implementacion por constructor y usarla para resolver el resto de dependencias segun vayamos necesitandolo.

```Csharp
public class ClaseDI
{
    private readonly IServiceProvider _serviceProvider;

    public ClaseDI(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    private async Task MetodoEjecutaDependencia()
    {
        var userAction = _serviceProvider.GetRequiredService<IUserAction>();
        var respUsuarios = await userAction.GetAllUsers();
    }
}
```

## DI en Console Application
1. Necesitamos crear un Objeto `IHostBuilder`, Microsoft tiene por defecto una factoria base que te devuelve dicho objeto, y es el metodo `Host.CreateDefaultBuider(args)`.

2. Agregamos la configuracion de logging, eso hace que cuando se use el objeto `ILogger` se pinte con dicha configuración.

3. Agregamos la configuracion de servicios al contenedor de dependencias.  
En este apartado agregamos los servicios como la configuracion de la Base de Datos, los servicios de la aplicacion, etc.  
Como dato **importante**, los servicios de la aplicacion deberan de agregarse con el tipo `Transient`

4. Ejecutamos el metodo `Build()`, este metodo se encargará de implementar las configuraciones y devolver un objeto de tipo `IHost` que contendra la configuración anterior y podremos realizar procesos como correr la aplicacion, etc.

5. Después de buildear la aplicación, se pueden hacer dos cosas.
    1. Ejecutar la aplicacion con un `await app.RunAsync();`, se ejecutara al consola y se quedara escuchando que es lo que se requiere de hacer. Util cuando se quieren realizar procesos cada cierto tiempo, etc.
    2. Mediante el objeto generado del `Build()`, se puede realizar un `app.Services.GetRequiredService<IClasePuntoDeEntrada>();` y ejecutar el metodo que inicia la aplicacion, por ejemplo, `clasePuntoDeEntrada.Main()`.

```Csharp
var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureLogging((hostContext, log) =>
{
    log.AddConfiguration(hostContext.Configuration);
    log.AddConsole();
});

builder.ConfigureServices((hostContext, services) =>
{
    services.AddOptions();
    services.AddDbContextFactory<EjemploContext>(options =>
    {
        options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(EjemploContext)), sql =>
        {
            sql.MigrationsAssembly(typeof(Program).Assembly.FullName);
        });
    });
    services.AddTransient(p => p.GetRequiredService<IDbContextFactory<EjemploContext>>().CreateDbContext());

    services.AddTransient<IClasePuntoDeEntrada, ClasePuntoDeEntrada>();
});

var app = builder.Build();

var migrations = app.Services.GetRequiredService<MigrationService>();
await migrations.StartAsync(CancellationToken.None);

```

## DI en Desktop Application
1. Necesitamos crear un Objeto `IHostBuilder`, Microsoft tiene por defecto una factoria base que te devuelve dicho objeto, y es el metodo `Host.CreateDefaultBuider(args)`.

1. Agregamos la configuracion para indicar el `Environment` en el que estamos, muy util para realizar ciertas acciones segun si estamos en `Development` o `Production`

1. Agregamos la configuracion de la aplicacion mediante archivos `JSON` basandonos tambien en el nombre del entorno de ejecucion para cargar un archivo u otro.  
Generalmente en estos archivos se almacenan los datos de acceso de la base de datos, etc.  
Para acceder a esta configuracion se debe de implementar el objeto `IConfiguration`.

1. Agregamos la configuracion de servicios al contenedor de dependencias.  
En este apartado agregamos los servicios como la configuracion de la Base de Datos, los servicios de la aplicacion, etc.  
Como dato **importante**, los servicios de la aplicacion deberan de agregarse con el tipo `Transient`.

1. Ejecutamos el metodo `Build()`, este metodo se encargará de implementar las configuraciones y devolver un objeto de tipo `IHost` que contendra la configuración anterior y podremos realizar procesos como correr la aplicacion, etc.

1. Mediante el objeto generado del `Build()`, se puede realizar un `app.Services.GetRequiredService<MainWindow>();` y ejecutar el metodo que inicia la aplicacion, por ejemplo, `presentation.Show()`.

```Csharp
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        var builder = Host.CreateDefaultBuilder(e.Args);

        builder.UseEnvironment(System.Environment.GetEnvironmentVariable("DESKTOP_ENVIRONMENT") ?? "Production");

        builder.ConfigureAppConfiguration((hostContext, configBuilder) =>
        {
            configBuilder.AddJsonFile("appsettings.json");
            configBuilder.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
        });

        builder.ConfigureServices((hostContext, services) =>
        {
            services.AddOptions();

                // services.AddFrontend();
                services.AddTransient<MainWindow>();

                // services.AddBackendBusiness();
                // Actions
                services.AddTransient<IUserAction, UserAction>();

                // Managers
                services.AddTransient<IUserManager, UserManager>();

                // services.AddBackendData();
                services.AddTransient<IUserDam, UserDam>();

            services.AddDbContextFactory<ContextoSqlServer>(options =>
            {
                options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(ContextoSqlServer)));
            });
            services.AddTransient(p => p.GetRequiredService<IDbContextFactory<ContextoSqlServer>>().CreateDbContext());

        });
        var app = builder.Build();

        app.Services.GetRequiredService<MainWindow>().Show();
    }
}
```

## DI en Web Application
1. Necesitamos crear un Objeto `WebApplicationBuilder`, Microsoft tiene por defecto una factoria base que te devuelve dicho objeto, y es el metodo `WebApplication.CreateBuilder(args)`.

1. Agregamos la configuracion de servicios al contenedor de dependencias.  
En este apartado agregamos los servicios como la configuracion de la Base de Datos, los servicios de la aplicacion, etc.  
    1. Se agrega al contenedor de dependencias las `Paginas de Razor`
    1. Se agrega al contenedor de dependencias las configuracion ubicada en el objeto `builder.Configuration`.

1. Ejecutamos el metodo `Build()`, este metodo se encargará de implementar las configuraciones y devolver un objeto de tipo `WebApplication` que contendra la configuración anterior y podremos realizar procesos como correr la aplicacion, Middlewares, etc.

1. Miramos si estamos en un entorno distinto al de desarrollo para poder implementar un Middleware de excepciones controladas para que cuando ocurra, se haga un Redirect a una Page y la implementacion `Hsts`.

1. Con el objeto generado del `Build()`, implementamos los Middlewares a usar, en este caso:
    1. `UseHttpsRedirection`: Middleware que se encarga de revisar si las peticiones van por `HTTP` y realizar un redirect de la misma al protocolo `HTTPS`.
    1. `UseStaticFiles`: Middleware que se encarga de analizar los archivos estaticos que se requieren y enviarlos con la solicitud de respuesta.
    1. `UseRouting`: Middleware que analiza la solicitud y revisa los puntos de conexion creados en la aplicacion e intenta encontrar cual es la mejor coincidencia para saber a que Page tiene que enrutar.
    1. `UseAuthorizacion`: Middleware que se encarga de realizar una comprobación de autorizacion sobre una pagina.  
    Basicamente verifica si la persona que solicita la conexion tiene los permisos necesarios para visualizar el contenido al que esta solicitando acceso, etc.  
    **Importante** se tiene que crear despues de `UseRouting o UseEndpoints`, puesto que necesita saber a que ruta se va a acceder, 

1. Mapeamos las paginas Razor para linkarlas con las rutas de acceso, de esta forma cuando nos soliciten una URL, sabremos a que pagina debemos de acceder y por ende, devovler.

1. Ejecutamos la aplicación para empezar a poder recibir y gestionar peticiones.

```Csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAppConfiguration(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

await app.RunAsync();
```

# ApplicationBuilder


## Middleware

```Csharp

```

# EntityFramework Core


## 

```Csharp

```

# Dapper


##

```Csharp

```

#