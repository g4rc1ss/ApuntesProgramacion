La inversión de dependencias es un principio que describe un conjunto de técnicas destinadas a disminuir el acoplamiento entre los componentes de una aplicación. 

La inversión de dependencias suele también conocerse como inversión de control.

Muy resumidamente, el Principio de Inversión de Dependencias propone evitar las dependencias rígidas entre componentes mediante las siguientes técnicas:

- Utilizar abstracciones (interfaces) en lugar de referencias directas entre clases, lo que facilita que podamos reemplazar componentes con suma facilidad.
- Hacer que una clase reciba referencias a los componentes que necesite para funcionar, en lugar de permitir que sea ella misma quien los instancie de forma directa o a través de factorías.

# Tipos de DI
A la hora de registrar la dependencia, tenemos 3 opciones que difieren en el **tiempo de vida**.

El contenedor mantiene todos los servicios que crea y una vez su tiempo de vida (lifetime) termina, son disposed.

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

Cuando programamos, definir que tipo de `lifetime` vamos a dar a nuestros servicios es importante, pero no solo eso, sino que debemos asegurarnos que nuestros servicios no dependen en otros servicios con tiempos de vida menores que ellos. Esto es debido a que así evitaremos errores o funcionamientos extraños durante el tiempo de ejecución. Si mi servicio `Scope` depende de un servicio `Transient`, puede que la dependencia transient, al tener un tiempo de vida menor, sea liberada y el scope pueda ver su proceso alterado o incluso saltar una excepcion.

# Formas de uso de DI
Despues de registrar el servicio que queremos implementar en la inyeccion de dependencias, requerimos de poder hacer uso de el en el resto del codigo.

Para esta finalidad hay varias formas de hacerlo.

## Por Constructor
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
}
```

## Por Atributo
Creamos las variables privadas de solo lectura y les ponemos el atributo `[Dependency]` para indicar al Inyector de Dependencias las instancias que debe de resolver.

Es un metodo menos común de uso, pero igualmente eficaz.

```Csharp
public class ClaseDI
{
    [Dependency]
    private readonly IUserAction _userAction;
}
```

## IServiceProvider
Otra forma de resolver dependencias es mediante el uso de `IServiceProvider`, Podemos recibir la implementacion por constructor y usarla para resolver el resto de dependencias segun vayamos necesitandolo.

```Csharp
public class ClaseDI
{
    private readonly IServiceProvider _serviceProvider;

    public ClaseDI(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _serviceProvider.GetRequiredService<IUserAction>();
    }
}
```

### CreateScope
Cuando queremos resolver dependencias del tipo `Scope`, por ejemplo, en una aplicacion de consola que implementamos un `DbContext` o queremos crear nuestro scope como tal, hay una metodo que nos ayuda con ello.
```Csharp
public class ClaseDI
{
    private readonly IServiceProvider _serviceProvider;

    public ClaseDI(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        using(var service = _serviceProvider.CreateScope())
        {
            var userAction = service.ServiceProvider.GetRequiredService<IUserAction>();
        }
    }
}
```

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
    services.AddTransient<IUserDam, UserDam>();
});
var app = builder.Build();
```

## Host Web
Este tipo de host es igual al de arriba, la unica diferencia es que cuando se ejecute el metodo `RunAsync()` sera capaz de procesar peticiones **http**
```Csharp
var builder = WebApplication.CreateBuilder(args);

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
