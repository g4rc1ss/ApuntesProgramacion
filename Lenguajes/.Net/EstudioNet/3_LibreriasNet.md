# User Secrets
Los **User secrets** son datos especificos que contienen datos como contraseñas, claves de API, cadenas de conexion, etc. Por lo que necesitamos tenerlas fuera del repositorio y de compartirlas con otros desarrolladores.

## Secret Manager
Una vez creado el proyecto principal, el que contiene los archivos de configuración, le damos al click derecho sobre el proyecto y buscamos la opción `Manage User Secrets`.

Esta opción generará un elemento `<userSecretsId>` en el `.csproj` del proyecto y se almacenara ese id en el programa.  
A su vez el programa creará un archivo llamado **secrets.json** que estará ubicado fuera del proyecto. Por defecto se ubica en:
- Windows `%APPDATA%\microsoft\UserSecrets\<userSecretsId>\secrets.json`
- Mac `~/.microsoft/usersecrets/<userSecretsId>/secrets.json`
- Linux `~/.microsoft/usersecrets/<userSecretsId>/secrets.json`

Para poder acceder a dicho archivo, se podra hacer desde el objeto `IConfiguration` con la configuracion por defecto.


# Dependency Injection
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
    
    ![image](https://user-images.githubusercontent.com/28193994/147787498-49329783-696b-4de6-a2be-33cbd3770fd4.png)


- **Scoped**: Si creamos un servicio que está registrado como scoped este vivirá por el tiempo de vida que exista ese scope.  
    - En `ASP.NET Core` la aplicación crea un scope para cada request que recibe, por tanto, se creara un scope cada vez que la aplicacion reciba una peticion.  
    Lo que quiere decir, que todos los servicios que se utilicen a traves de esa Request que necesiten resolver la dependencia Scope, usaran la misma.

![image](https://user-images.githubusercontent.com/28193994/147787541-d30ebe2c-4c8a-4568-990a-ca2ded321ce5.png)


- **Singleton**: La dependencia se va a resolver una sola vez en todo el codigo y a partir de ahí, cada vez que se solicite, se va a reutilizar dicha dependencia.
    - Si el servicio se utiliza muy frecuentemente puede proveer mejora en el rendimiento ya que se instancia una vez para la aplicación entera y no uno por servicio como `Transient`. 
    - Si utilizamos singleton debemos crear la clase a la que referencia o bien completamente inmutable ya que al ser la misma instancia en caso de ser mutable podría dar errores inesperados.
    - Utilizar técnicas donde nos aseguramos que la aplicación va a ser thread-safe. Un ejemplo muy común de singleton es caché en memoria.

![image](https://user-images.githubusercontent.com/28193994/147787579-3aba78aa-9071-4fa1-9552-a5540b6b3302.png)

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

## Implementar DI en proyectos
La inyeccion de dependencias se puede implementar en todos los tipos de proyectos actuales de .Net

### Console Application
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

### Desktop Application
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

### Web Application
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


# Utilizar Cache


## IMemoryCache



## IDistributedCache





# IOptions
La implementacion del *Options Pattern* nos aporta poder encapsular y separar la lógica de la configuracion de la aplicacion del resto de componentes.

Para poder hacer uso de este servicio, necesitaremos instalar `Microsoft.Extensions.Options`.

Para implementar el patron Options tenemos que agregarlo con el objeto `IConfiguration` en la inyeccion de dependencias.

Llamamos al metodo `Configure` pasandole una clase sobre la que mapeara la configuracion contenida en la section indicada.
```Csharp
builder.services.Configure<T>(Configuration.GetSection("seccion"));
```

**Los beneficios que nos aporta este patron son:**
1. Utilizarlo, nos fuerza a tener nuestra configuración **fuertemente tipada** y así, evitar errores.
1. Cuando revisamos código, o simplemente lo leemos después de un tiempo, es mucho más sencillo de entender si nuestro tipo de configuración se llama `IOptions<T>`, así sabemos de dónde viene.

Si, por ejemplo, necesitamos hacer uso de validaciones o algun proceso de verificación de datos podemos usar el metodo `PostConfiguration` despues de usar el metodo `Configure<T>`.

```Csharp
builder.services.Configure<T>(Configuration.GetSection("seccion"));
builder.services.PostConfigure<T>(configuration =>
{
    if ( string.IsNullOrWhiteSpace(configuration.property))
    {
        throw new ApplicationException("");
    }
});
```

## Cuando usar los patrones
La elección entre las diferentes interfaces del patrón `IOptions` dependerá de tu caso de uso, puesto que estos varían segun sus tiempos de vida.

- `IOptions` si no vas a cambiar la configuración.

- `IOptionsSnapshot` si vas a cambiar la configuración.

- `IOptionsMonitor` si necesitas cambiar la configuración constantemente o detectas que ese cambio puede pasar en el medio de un proceso.

### IOptions
Con esta opcion, nuestra configuracio se crea en el contenedor de dependencias como singleton, por lo que si la modificamos, no se podra visualizar dicho cambio.

```Csharp
private readonly T _configuracionCreada;

public Clase(IOptions<T> configuracionCreada)
{
    _configuracionCreada = configuracionCreada.Value;
}
```

### IOptionsSnapshot
Si implementamos esta interfaz, se creara una instancia del objeto correspondiente una vez por Request(**scoped**) la cual va a ser inmutable.

La ventaja principal es que nos permite cambiar el valor de la configuracion en tiempo de ejecución, de esta forma, no hará falta hacer un despliegue para ello.

![image](https://user-images.githubusercontent.com/28193994/147843223-464ee4fe-16a2-40e0-9e4d-a58a81640a94.png)

La forma de acceder es la misma, pero implementando esta interfaz

```Csharp
private readonly T _configuracionCreada;

public Clase(IOptionsSnapshot<T> configuracionCreada)
{
    _configuracionCreada = configuracionCreada.Value;
}
```

### IOptionsMonitor
`IOptionsMonitor<T>` se inyecta en nuestro servicio como `Singleton` y funciona de una manera especial, ya que en vez de acceder a .Value para acceder a T como hacíamos anteriormente, ahora realizamos `.CurrentValue` el cual nos devuelve el valor en el momento.

Esto quiere decir que si cambias el valor a mitad de la request o mitad de un proceso, este obtendrá el valor actualizado:

![image](https://user-images.githubusercontent.com/28193994/147843227-51c7f8c0-55cf-4897-a434-da23cf136f40.png)

La forma de acceder es un tanto diferente:
```Csharp
private readonly IOptionsMonitor<T> _configuracionCreada;

public Clase(IOptionsMonitor<T> configuracionCreada)
{
    _configuracionCreada = configuracionCreada;
}

// Para acceder a la informacion:
_configuracionCreada.CurrentValue.Property
```


# IDataProtectionProvider
Es importante mantener la informacion sensible protegida, por si se diera el caso de una filtracion de datos o similares, es fundamental tener dichos datos encriptados.

Microsoft provee de una implementacion que se llama `IDataProtectionProvider`.

Este sistema de cifrado usa unas claves ubicadas en `%LOCALAPPDATA%\ASP.NET\DataProtection-Keys` generadas por el propio programa. [Mas info](https://docs.microsoft.com/es-es/aspnet/core/security/data-protection/configuration/default-settings?view=aspnetcore-6.0)

El algoritmo utiliza las claves ubicadas fisicamente con un `purpose` que tendremos que pasar para proteger y desproteger. El motivo de esto es que si, por ejemplo, tenemos un elemento protegido con el `purpose` *"identificador 1"* y tratamos de desprotegerlo con una instancia de `purpose` *"identificador 2"*, no deberia de ser capaz de realizar la accion.

Los `purpose` no estan pensados para estar en `vaults` ni nada por el estilo, se pueden hardcodear sin problema.

## Implementar por Inyeccion de dependencias
Para poder hacer uso de este servicio, necesitamos implementar en la inyeccion de dependencias el servicio:
```Csharp
builder.Services.AddDataProtection();
```

Una vez registrado, realizamos la inyeccion de dependencia en el contructor y creamos el "*protector*"

## Implementar en entornos no compatibles con DI
Para poder usar este servicio en un entorno no compatible con la inyeccion de dependencias necesitamos usar el paquete `Microsoft.AspNetCore.DataProtectorExtensions` para obtener el tipo `DataProtectionProvider`.

Para instanciar `DataProtectionProvider` necesitamos mandarle un objeto `DirectoryInfo` que debe de contener el path donde se ubican las claves criptograficas a usar.

```Csharp
// Get the path to %LOCALAPPDATA%\myapp-keys
var destFolder = Path.Combine(
    System.Environment.GetEnvironmentVariable("LOCALAPPDATA"),
    "myapp-keys");

// Instantiate the data protection system at this folder
var dataProtectionProvider = DataProtectionProvider.Create(
    new DirectoryInfo(destFolder));

var protector = dataProtectionProvider.CreateProtector("Program.No-DI");
Console.Write("Enter input: ");
var input = Console.ReadLine();

// Protect the payload
var protectedPayload = protector.Protect(input);
Console.WriteLine($"Protect returned: {protectedPayload}");

// Unprotect the payload
var unprotectedPayload = protector.Unprotect(protectedPayload);
Console.WriteLine($"Unprotect returned: {unprotectedPayload}");
```

## Proteger la información
Para crear el protector tenemos que mandarle un `purpose`, este parametro por convencion suele ser el namespace y el nombre de tipo del componente.
```Csharp
public class PutPersonalProfile
{
    private readonly IDataProtector _protector;

    public PutPersonalProfile(IDataProtectionProvider protectorProvider)
    {
        _protector = protectorProvider.CreateProtector("purpose");
    }
}
```

### Proteger
Una vez tenemos una instancia de `IDataProtector` debemos de realizar la funcion de cifrado.

```Csharp
_protector.Protect(profileDto.Email);
```

### Desproteger
Cuando necesitamos descifrar debemos de hacer los mismos pasos y usar el metodo `Unprotect()`

```Csharp
_protector.Unprotect(values.personalProfile.Email)
```


# Middleware
Un Middleware es una clase que permite manipular una peticion o respuesta HTTP

El proceso de ejecución de un Middleware se realiza cuando llega la `Request`, se pasan por los distintos Middlewares hasta ejecutar el proceso principal de la peticion y cuando este proceso devuelve el response, se pasa por los Middleare en sentido opuesto hasta que salga la peticion hacia el usuario.

![image](https://user-images.githubusercontent.com/28193994/147764665-091176bb-811a-43be-b010-980a94df5b3a.png)

Cabe destacar que el orden es importante, ya que como he indicado se van ejecutando uno detrás de otro. 

Hay que tener en cuenta, que podemos crear un middleware que en ciertas condiciones nos crea una respuesta directamente, esta acción lo que haría sería evitar que los middleware que vienen después no se ejecuten. 

### Crear un Middleware
Para crear un Middleware necesitamos implementar la interfaz `IMiddleware` que nos creara el metodo `Task InvokeAsync(HttpContext context, RequestDelegate next)`
1. Implementamos la dependencia `ILogger`, puesto que vamos a registrar por logs las respuestas que se reciben de la aplicación.

1. La función `InvokeAsync` recibe el `HttpContext` y el `RequestDelegate`
    1. El `HttpContext` contiene todos los datos de la peticion, tanto el `Request` como el `Response` entre otras cosas.
    1. El `RequestDelegate` contiene el siguiente middleware a ejecutar, si no hay ningun Middleware mas, se pasará a ejecutar el proceso principal de la petición

1. La ejecución del Middleware funciona de la sigueinte forma.
    1. Ejecutamos codigo antes de la ejecucion del proceso principal y el resto de Middlewares.
    1. Ejecutamos la función `await next(context);`. Este delegado pasa al sigueinte Middleware sucesivamente hasta el proceso principal de la petición(la lógica de negocio).
    1. Cuando el proceso del delegado anterior termina, se ejecuta el codigo que queremos realizar despues de la petición.  
    Una vez finalizada la función se iran pasando a los anteriores Middlewares hasta que se devuelva la petición al usuario que solicito la Request.

```Csharp
public class EjemploMiddleware : IMiddleware
{
    private readonly ILogger<EjemploMiddleware> _logger;

    public EjemploMiddleware(ILogger<EjemploMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Lo que se ejecuta antes de la resolucion de la request
        using var memoryStream = new MemoryStream();
        var original = context.Response.Body;

        context.Response.Body = memoryStream;
        _logger.LogInformation($"Request Path {context.Request.Path.Value}");

        // La llamada a la siguiente ejecucion correspondiente del Middleware hasta que se resuelva la Request
        await next(context);

        // Lo que se ejecuta despues de la resolucion de la request
        memoryStream.Seek(0, SeekOrigin.Begin);
        var data = await new StreamReader(context.Response.Body).ReadToEndAsync();
        memoryStream.Seek(0, SeekOrigin.Begin);

        _logger.LogInformation($"Datos del Response {data}");
        await memoryStream.CopyToAsync(original);
        context.Response.Body = original;
    }
}
```
Para implementarlo
1. Agregamos la clase al contenedor de dependencias para poder usar dependencias como `ILogger`, etc.
1. Usando el objeto `app` que contiene la instancia de `WebApplication` ejecutamos el metodo `UseMiddleware<EjemploMiddleware>();` para registrarlo en el proceso de la Request.

```csharp
builder.Services.AddScoped<EjemploMiddleware>();
app.UseMiddleware<EjemploMiddleware>();
```


# Dapper
Es un Micro-ORM(Object Relational Mapper) creado por `Stackoverflow` encargado de ejecutar queries SQL y devolver el resultado mapeado en un objeto.

## **Caracteristicas de Dapper**
Las caracteristicas principales de Dapper son.

- **Consulta y Mapeo**: Dapper en concreto se centra en hacer un mapeo rápido y preciso de nuestros objetos, además los parámetros de las queries están parametrizados, con lo que evitaremos inyección SQL. 
- **Rendimiento**: Dapper es el rey de los ORM en términos de rendimiento, para conseguir esto, extiende la interfaz `IDbConnection`, lo que implica que es un poco más cercano “al core” del lenguaje, y nos da beneficios de rendimiento. Dapper tiene en su página de [GitHub](https://github.com/DapperLib/Dapper#performance) una lista con el rendimiento comparado con otros ORM.
- **Api muy sencilla**:  El objetivo de dapper es hacer un par de funcionalidades y hacerlas todas muy bien. La api, nos provee de tres tipos de métodos.
    - Métodos que mapean tipos concretos.
    - Métodos que mapean tipos dinámicos.
    - Métodos para ejecutar comandos, como por ejemplo insert o delete;

- **Cualquier Base de Datos**: Al trabajar directamente con `IDbConnection`, permite utilizar las librerias de conexion de otras bases de datos, como MySQL, SqlServer, Postgres, etc.

## Dependency Injection with Dapper
Dapper extiende directamente de la interfaz `IDbConnection`, por tanto para mandar el objeto de conexion mediante Inyeccion de dependencias, se debera de usar dicha interfaz.

```Csharp
services.AddScoped<IDbConnection>(service => new SqlConnection(configuration.GetConnectionString("Database")));
```

## Ejecución de Consultas
Dapper tiene la opcion de realizar la ejecucion de las consultas de forma `sincrona` y `asincrona`

### SELECT
Hay varias funciones para realizar consultas con Dapper.

#### QueryFirstOrDefault<>
Cuando queremos realizar una consulta que solamente va a devolver una fila, ejecutamos el metodo `QueryFirstOrDefault`, que nos devolvera una instancia del objeto mapeado que solicitamos

```Csharp
await con.QueryFirstOrDefaultAsync<T?>($"SELECT * FROM {TableName} where UserId = @userId", new
{
    userId = userId
});
```

#### Query<>
Cuando queremos obtener una lista de objetos mapeados de una query, usamos el metodo `QueryAsync` y este nos devolvera un objeto `IEnumerable<T>` que podremos iterar, mapear a un `List`, etc.

```Csharp
await con.QueryAsync<T>($"SELECT * FROM {TableName} where UserId = @userId", new
{
    userId = userId
});
```

#### Consultas relacionadas
Cuando queremos ejecutar consultas relacionadas, queremos mapear objetos completos, por ejemplo, un usuario pertenece a un municipio y tenemos una clase `Usuario` y una clase `Pueblo`,

La entidad usuario es la siguiente:

```Csharp
public class Usuario
{
    public string IdUsuario { get; set; }
    public string NombreUsuario { get; set; }

    public Pueblo FKPueblo { get; set; }
}

internal class Pueblo
{
    internal string IdPueblo { get; set; }
    internal string NombrePueblo { get; set; }
}
```

Por tanto queremos realizar la siguiente consulta para obtener un listado de usuarios, con el correspondiente pueblo tendremos que realizar nosotros mismos el mapeo.

1. Creamos la query SQL en orden, primero deberemos de seleccionar lo correspondiente a un objeto todos los parametros y despues el siguiente, en este caso, primero los parametros de usuario y despues los del pueblo correspondiente al usuario
1. La funcion `Query<T1, T2, TResult>` se le pasan los parametros de los objetos que tiene que crear y por ultimo el objeto resultante, en este caso, primero indicamos la clase `Usuario`, despues `Pueblo` y por ultimo indicamos que el objeto a devolver es `Usuario`
    1. En el primer parametro indicamos el mapeo a realizar y donde tenemos que ubicar los diferentes objetos
    1. En el segundo parametro le pasamos un objeto para la query parametrizada, de esta forma evitamos ataques SQL Injection
    1. En el parametro llamado `splitOn` tenemos que indicar el objeto a partir del cual debemos separar los objetos a crear, en este caso indicamos que cada vez que se encuentre el nombre "IdPueblo" se debe de mapear el siguiente objeto.  
    Tener en cuenta que en el caso de que haya mas objetos a mapear, se deberan separar por comas `,`, por ejemplo `IdPueblo,OtroId`

```Csharp
var sqlPueblo = @$"SELECT user.Id as {nameof(Usuario.IdUsuario)}
                    ,user.Nombre as {nameof(Usuario.NombreUsuario)}
                    ,village.Id as {nameof(Pueblo.IdPueblo)}
                    ,village.Nombre as {nameof(Pueblo.NombrePueblo)}
                FROM {nameof(Usuario)} as user
                INNER JOIN {nameof(Pueblo)} as village ON user.IdPueblo = village.Id
                WHERE user.Id = @idUsuario";
var respuestaPueblo = await connection.QueryAsync<Usuario, Pueblo, Usuario>(sqlPueblo, (user, pueblo) =>
{
    user.FKPueblo = pueblo;
    return user;
}, new
{
    idUsuario = "IdUsuario3"
}, splitOn: $"{nameof(Pueblo.IdPueblo)}");
```

#### QueryMultiple
A veces para obtener una serie de datos, necesitamos realizar varias consultas diferentes. Para ello dapper permite la ejecucion de varias queries juntas en orden.

1. Creamos la `sql` con las diferentes queries, para separarlas se pone el `;` al finalizar la query correspondiente.
1. Ejecutamos el metodo `QueryMultiple` con la SQL
1. Obtenemos los resultados de dicha query de forma ordenada.  
Si primero realizamos una Select sobre los usuarios, debemos de ejecutar el metodo `Read<>` de usuarios y asi sucesivamente.

```Csharp
var sqlMultipleUserPueblo = $@"
SELECT Id as {nameof(Usuario.IdUsuario)}
    ,Nombre as {nameof(Usuario.NombreUsuario)}
FROM Usuario
ORDER BY Id;

SELECT Id as {nameof(Pueblo.IdPueblo)}
    ,Nombre as {nameof(Pueblo.NombrePueblo)}
FROM Pueblo
ORDER BY Id;
";
var queryMultiple = await connection.QueryMultipleAsync(sqlMultipleUserPueblo);
var users = await queryMultiple.ReadAsync<Usuario>();
var villages = await queryMultiple.ReadAsync<Pueblo>();
```

### INSERT
Para insertar un registro nuevo en la Base de Datos con Dapper, se deberá de crear la sql correspondiente y ejecutar la función `ExecuteAsync` que devolvera el numero de registros modificados.

```Csharp
var guidPueblo = Guid.NewGuid();
var insertIntoPueblo = @$"
insert into {nameof(Pueblo)} (id, nombre)
values (@guidPueblo, @NombrePueblo)";
var nChangesPueblo = await connection.ExecuteAsync(insertIntoPueblo, new
{
    guidPueblo,
    NombrePueblo = "Albacete"
});
```

#### Insert varias queries
Para insertar varias queries con dapper, simplemente debemos separar las `INSERT INTO` con `;` y mandar la sql en la funcion de `ExecuteAsync()`

```Csharp
var insert = @$"
insert into {nameof(Pueblo)} (id, nombre)
values (@guidPueblo, @NombrePueblo);

insert into {nameof(Usuario)} (id, nombre, idpueblo)
VALUES (@guidUsuario, @nombreUsuario, @guidPueblo);";

var nChanges = await connection.ExecuteAsync(insert, new
{
    guidPueblo = Guid.NewGuid(),
    NombrePueblo = "Albacete",
    guidUsuario = Guid.NewGuid(),
    nombreUsuario = "garciss",
});
```

### UPDATE
Para actualizar registros de la base de datos con `Dapper` ejecutamos igualmente `ExecuteAsync()`

```Csharp
var updatePueblo = @$"
UPDATE {nameof(Pueblo)}
SET Id = '{Guid.NewGuid()}'
WHERE Id = @idPueblo;

UPDATE {nameof(Usuario)}
SET Id = '{Guid.NewGuid()}'
WHERE Id = @idUsuario";
var nChanges = await connection.ExecuteAsync(updatePueblo, new
{
    idPueblo = "IdPueblo1",
    idUsuario = "IdUsuario1",
});
```

### DELETE
Para borrar registros de la base de datos con `Dapper` ejecutamos igualmente `ExecuteAsync()`

```Csharp
var deleteUsuario = @$"
DELETE FROM {nameof(Usuario)} 
WHERE Id = @idUsuario";
var nChangesUsuario = await connection.ExecuteAsync(deleteUsuario.ToString(), new
{
    idUsuario = "IdUsuario2"
});

Console.WriteLine($"Borrado {nChangesUsuario} registros");
```


# Entity Framework Core
Es un ORM(Object Relational Mapper) creado por `Microsoft` encargado de crear las queries SQL para la Base de datos y mapear los resultados.

El funcionamiento de este **Framework** hace uso de la interfaz `IQueryable<T>` junto con la libreria `Linq` para generar la consulta `SQL`.

Entity Framework es compatible con diferentes [proveedores de bases de datos](https://docs.microsoft.com/es-es/ef/core/providers/).

## Implementacion de EF Core
Con EF Core, el acceso a datos se realiza mediante un modelo. Un modelo se compone de clases de entidad y un objeto de contexto que representa una sesión con la base de datos. Este objeto de contexto permite consultar y guardar datos.

EF admite los siguientes métodos de desarrollo de modelos:

- Generar un modelo a partir de una base de datos existente.
- Codificar un modelo manualmente para que coincida con la base de datos.
- Una vez creado un modelo, usar Migraciones de EF para crear una base de datos a partir del modelo. Migraciones permite que la base de datos evolucione a medida que el modelo va cambiando.

### DbContext
Esta clase seria el equivalente a una Base de Datos, si para el proyecto se usan, por ejemplo, 3 bases de datos diferentes, tendremos que implementar el mismo numero de contextos.

**Es importante** tener en cuenta que los contextos son **Thread safe**, por tanto, no se podra usar paralelismo en el mismo contexto para ejecutar las queries.

1. Para crear un contexto, debemos de heredar de la clase `DbContext`
1. Implementamos propiedades del tipo `DbSet<T>`. Estas propiedades son lo equivalente a una tabla de base de datos y el nombre de la propiedad, será el nombre de la tabla. Con estas propiedades es donde haremos las tareas de **CRUD** sobre la tabla.
1. Creamos un constructor
1. Sobreescribimos el metodo `OnConfiguring` donde recibiremos un objeto `DbContextOptionsBuilder`, esta clase se encarga de realizar la configuracion de la conexion sobre la base de datos, por ejemplo, establecer la cadena de conexion, la sensibilidad de logging, usar MemoryCache para cachear el contexto, etc.
1. Sobreescribimos el metodo `OnModelCreating` donde recibimos un objeto de tipo `ModelBuilder` que se encarga de configurar el modelo en su creacion para que el framework sea capaz de interpretar la base de datos, se podran especificar relaciones, configurar nuevas `DbFunction` por si el proveedor no tiene implementado el uso de alguna, etc.

```Csharp
public class ContextoSqlServer : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }

    public ContextoSqlServer() : base()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Cadena de conexion");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
```

### EF Core con Dependency Injection
Para poder hacer uso de EF Core con la DI, habra que hacer un par de cambios de lo visto arriba.

El contexto deberá de tener un constructor que reciba un `DbContextOptions` y eliminaremos el metodo `OnConfiguring`, puesto que esta configuracion se establecer al registrar el servicio.

```Csharp
public class ContextoSqlServer : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }

    public ContextoSqlServer(DbContextOptions<ContextoSqlServer> contextOptions) : base(contextOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
```

#### AddDbContext
Al registrar el contexto usando esta opcion se creará un `DbContext` por cada **Request** y se eliminará cuando esta finalice.

```Csharp
services.AddDbContext<ContextoSqlServer>(options =>
{
    options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(ContextoSqlServer)));
});
```

Cuando no disponemos de un tiempo de vida de tipo `scoped` debemos de implementar el tipo `transient`, por ejemplo, cuando realizamos la DI en una aplicacion Desktop.

```Csharp
services.AddDbContext<ContextoSqlServer>(options =>
{
    options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(ContextoSqlServer)));
},
contextLifetime: ServiceLifetime.Transient,
optionsLifetime: ServiceLifetime.Transient);
```

#### AddDbContextPool
**Esta opción no se puede utilizar sin un entorno `scoped`**

DbContextPool se utiliza para reutilizar contextos ya creados de bases de datos en vez de eliminarlos.

Sin el pooling, por defecto cada vez que nos llega una **request** se crea un contexto nuevo, se ejecuta el proceso correspondiente y cuando devolvemos el resultado, el contexto es eliminado. Si, por ejemplo, recibimos 1000 peticiones, seran creados 1000 contextos y eliminados cuando se acabe, esto puede dar lugar a perdidas de rendimiento.

El *DbContextPool* sirva para reutilizar los contextos que van a ser eliminados. Digamos que una peticion acaba, el contexto va a ser eliminado, pero como estamos recibiendo peticiones nuevas, se vuelve a mandar ese contexto a otro proceso nuevo, de esta forma evitamos la creacion de este.

```Csharp
services.AddDbContextPool<ContextoSqlServer>(options =>
{
    options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(ContextoSqlServer)));
});
```
---
Para implementar el servicio debemos de recibir el contexto por constructor.
```Csharp
private readonly ContextoSqlServer _contexto;

public UserDam(ContextoSqlServer contexto)
{
    _contexto = contexto;
}
```

#### AddDbContextFactory
Cuando necesitamos una factoria de contextos de bases de datos, debemos de usar esta opción.

Uno de los usos que se le puede dar a esta opción es la ejecucion de consultas paralelizadas puesto que los objetos `DbContext` no permiten el uso de multihilo para ello.

1. Agregamos la configuracion de la base de datos con el objeto de factoria
1. Por si se quiere implementar el contexto sin la factoria, registramos el servicio de un contexto creado.

```Csharp
services.AddDbContextFactory<ContextoSqlServer>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString(nameof(ContextoSqlServer)));
});
services.AddScoped(p => p.GetRequiredService<IDbContextFactory<ContextoSqlServer>>().CreateDbContext());
```

#### AddPooledDbContextFactory
Usando la factoria sin un objeto Pool, cada vez que creamos un contexto, lo usamos y lo eliminamos cuando no lo necesitemos.

Gracias a esta opcion, podremos ir reutilizando diferentes contextos creados en vez de ser directamente eliminados. Es un punto importante a valorar, puesto que puede suponer un aumento en el performance a la larga bastante considerable.

```Csharp
services.AddPooledDbContextFactory<EjemploContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString(nameof(EjemploContext)));
});
services.AddScoped(p => p.GetRequiredService<IDbContextFactory<EjemploContext>>().CreateDbContext());
```

### Migrations
En proyectos reales, los modelos de datos cambian a medida que se implementan características: se agregan o se quitan nuevas entidades o propiedades, y los esquemas de base de datos se deben cambiar según corresponda para mantenerlos sincronizados con la aplicación. Esto proporciona una manera de actualizar incrementalmente el esquema de la base de datos para mantenerla sincronizada con el modelo de datos de la aplicación al tiempo que se conservan los datos existentes en la base de datos.

A nivel general, las migraciones funcionan de esta forma:

- Cuando se introduce un cambio en el modelo de datos, se usan las herramientas para agregar una migración correspondiente en la que se describan las actualizaciones necesarias para mantener sincronizado el esquema de la base de datos. EF Core compara el modelo actual con una instantánea del modelo anterior para determinar las diferencias y genera los archivos de origen de la migración, de los que se puede realizar el seguimiento en el control de código fuente del proyecto como cualquier otro archivo de código fuente.
- Una vez que se ha generado una migración nueva, hay varias maneras de aplicarla a una base de datos. EF Core registra todas las migraciones aplicadas en una tabla de historial especial, lo que le permite saber qué migraciones se han aplicado y cuáles no.

#### Code First
La opcion de code first se utiliza cuando creamos la base de datos desde el codigo con EntityFramework, para ello tenemos que crear las migraciones y aplicarlas.

Hay que instalar el paquete `Microsoft.EntityFrameworkCore.Design`

Para crear las migraciones ejecutamos el siguiente comando.
```powershell
# Comando dotnet
dotnet ef migrations add InitialCreate

# Visual Studio
Add-Migration InitialCreate
```

Para aplicar las migraciones podemos ejecutar el siguiente comando.
```powershell
# Comando dotnet
dotnet ef database update

# Visual Studio
Update-Database
```

Para eliminar migraciones
```powershell
# Comando dotnet
dotnet ef migrations remove

# Visual Studio
Remove-Migration
```

#### Database First
Cuando preferimos crear la base de datos manualmente o ya la tenemos creada, por ejemplo, porque implementamos EF core en un proyecto que ya estaba creado, podemos hacer uso de un comando que nos crea todas las entidades con sus relaciones y el contexto ya configurado.

1. En el comando se agrega la cadena de conexion para mapear la base de datos y las relaciones
1. Indicamos el paquete Nuget que indica el tipo de base de datos al cual se va a conectar, en el ejemplo `Microsoft.EntityFrameworkCore.SqlServer`
1. La opcion `-Project` se usa porque debemos de ejecutar el comnado referenciando al proyecto que contiene `Microsoft.EntityFrameworkCore.Design`, pero puede que se quieran crear el contexto y las entidades a utilizar en otro proyecto, por ejemplo, en el proyecto de `Dominio`.

```powershell
# Visual studio
Scaffold-DbContext "Cadena de Conexion" Microsoft.EntityFrameworkCore.SqlServer -Project "Nombre.de.proyecto" -Force
```

Despues de tener los archivos de entidades y contexto creados, tendremos que echar un vistazo a la configuracion del `ModelBuilder` y del contexto, por ejemplo, en el DbContext seguramente tendremos que eliminar el metodo `OnConfiguring()`.

#### Crear migrations en otro proyecto
Si queremos tener las migraciones en otro proyecto, sea por organizacion o porque queremos crear un proyecto para aplicar las migraciones por ejemplo, podemos hacerlo agregando la opcion en la configuración del contexto de la siguiente forma.

```Csharp
options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(EjemploContext)), sql =>
{
    sql.MigrationsAssembly(typeof(Program).Assembly.FullName);
});
```

## Ejecucion de Consultas
Para la ejecucion de consultas en EF Core usaremos la libreria Linq de .Net.

La descripción siguiente es información general de alto nivel del proceso por el que pasa toda consulta.

1. Entity Framework Core procesa la consulta LINQ para crear una representación que está lista para que el proveedor de base de datos la procese.
    1. El resultado se almacena en caché para que no sea necesario hacer este procesamiento cada vez que se ejecuta la consulta.
1. El resultado se pasa al proveedor de base de datos.
    1. El proveedor de base de datos identifica qué partes de la consulta se pueden evaluar en la base de datos.
    1. Estas partes de la consulta se traducen al lenguaje de la consulta específico de la base de datos (por ejemplo, SQL para una base de datos relacional).
    1. Se envía una consulta a la base de datos y se devuelve el conjunto de resultados (los resultados son valores de la base de datos y no instancias de entidad).
1. Para cada elemento del conjunto de resultados
    1. Si se trata de una consulta con seguimiento, EF comprueba si los datos representan una entidad que ya existe en la herramienta de seguimiento de cambios para la instancia de contexto.
        1. Si es así, se devuelve la entidad existente.
        1. En caso contrario, se crea una entidad nueva, se configura el    seguimiento de cambios y se devuelve la entidad nueva.
    1. Si se trata de una consulta que no es de seguimiento, siempre se crea y devuelve una entidad nueva.

### Consulta
Cuando llama a los operadores LINQ, simplemente crea una representación de la consulta en memoria. La consulta solo se envía a la base de datos cuando se usan los resultados.

Las operaciones más comunes que generan que la consulta se envíe a la base de datos son:

- La iteración de los resultados en un bucle for
- Uso de operadores como ToList, ToArray, Single y Count, o sobrecargas asincrónicas equivalentes

#### Consultar todos los registros
```Csharp
from usuario in context.Usuarios
select usuario

await context.Usuarios.ToListAsync();
```

#### Where
```Csharp
from usuario in context.Usuarios
where usuario.Edad < 22
select usuario

context.Usuarios.Where(x => x.Edad < 22);
```

#### Order By
```Csharp
// ascending
from usuario in context.Usuarios
where usuario.Edad < 22
orderby usuario.Id
select usuario

context.Usuarios.Where(x => x.Edad < 22).OrderBy(x => x.Id);


// descending
from usuario in context.Usuarios
where usuario.Edad < 22
orderby usuario.Id descending
select usuario

context.Usuarios.Where(x => x.Edad < 22).OrderByDescending(x => x.Id);
```

#### Join
```Csharp
from usuario in context.Usuarios
join pueblo in context.Pueblos on usuario.PuebloId equals pueblo.Id
select new User
{
    Name = usuario.Nombre,
    Edad = usuario.Edad,
    Pueblo = new Pueblo
    {
        Nombre = pueblo.Nombre
    }
}

context.Usuarios.Join(context.Pueblos, user => user.PuebloId, pueblo => pueblo.Id, (user, pueblo) => new User
{
    Name = user.Nombre,
    Edad = user.Edad,
    Pueblo = new Pueblo
    {
        Nombre = pueblo.Nombre
    }
});
```

#### Group By
```Csharp
from chat in context.Chat
where (chat.UserIdTo == userId)
group chat by new 
{
    chat.UserIdFrom,
    chat.UserIdTo,
    UserIdFromEntityName = chat.UserIdFromNavigation.Name,
    UserIdFromEntityLastName = chat.UserIdFromNavigation.LastName,
    PropiedadNombre = chat.PropiedadIdNavigation.Nombre,
    chat.PropiedadId,
    chat.CreateMessage,
} into resultChat
orderby resultChat.Key.CreateMessage descending
select new ChatDao 
{
    ContactId = resultChat.Key.UserIdFrom,
    ContactName = resultChat.Key.UserIdFromEntityName,
    ContactLastName = resultChat.Key.UserIdFromEntityLastName,
    PropertyName = resultChat.Key.PropiedadNombre,
    PropertyId = resultChat.Key.PropiedadId,
    PendienteLeer = (from chat in context.Chat
                    where !chat.EstaLeido && resultChat.Key.PropiedadId == chat.PropiedadId
                    && chat.UserIdTo == userId && chat.UserIdFrom == resultChat.Key.UserIdFrom
                    select chat).Count()
}
```

### Guardado
1. **INSERT**: Usamos el metodo `DbSet.Add` para agregar instancias nuevas de las clases de entidad.
1. **UPDATE**: EF detecta automáticamente los cambios hechos en una entidad existente de la que hace seguimiento. Por tanto, obtenemos el registro a actualizar y modificamos el objeto.
1. **DELETE**: Usamos el método `DbSet.Remove` para eliminar las instancias de las clases de entidad.
1. **SaveChanges**: Guarda todos los cambios realizados en el contexto.  
Cabe destacar que se pueden realizar varias operaciones de guardado de datos juntas y ejecutar este metodo el ultimo, como en el ejemlo siguiente.

```Csharp
// agregamos registros nuevos
var pueblo = await context.Pueblos.AddAsync(new Database.DTO.Pueblo
{
    Nombre = "Soria"
});

await context.Usuarios.AddAsync(new Database.DTO.Usuario
{
    Nombre = "Nombre del usuario",
    Edad = 10,
    FechaHoy = DateTime.Now,
    PuebloId = pueblo.Entity.Id
});

// Actualizamos registros
var usuario = (from user in context.Usuarios
               where user.PuebloIdNavigation.Id == 4
               select user).FirstOrDefault();
usuario.Nombre = "cnifvbdilcbsuyvrg";

// borramos registros
var usuarios = (from user in context.Usuarios
                where user.Edad < 22
                select user).ToList();
context.RemoveRange(usuarios);

await context.SaveChangesAsync();
```


# Identity

