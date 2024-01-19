# Serilog
Es una libreria que automatiza el guardado de logs en diferentes proveedores de nuestra aplicación

Serilog tiene unos paquetes, que son extensiones llamados `Sinks` que son los que se encargan de realizar el envio de los logs, por ejemplo, para almacenarlos en una base de datos, en un insights, etc.

## Consola
Muestra el proceso de `logging` en la interfaz de la Consola, es buena opción para un entorno de desarrollo.

```Csharp
WriteTo.Console()
```

## Archivos de Texto
Guarda el proceso de Logging en un archivo de texto en el disco duro.
```Csharp
WriteTo.File(@"Path\log-.txt",
    rollingInterval: RollingInterval.Hour,
    rollOnFileSizeLimit: true,
    fileSizeLimitBytes: 2000,
    restrictedToMinimumLevel: LogEventLevel.Warning);
```
- **path**: Ruta de guardado del archivo, antes de la extension se rellenará la fecha de guardado.
- **rollingInterval**: Indicamos cada cuanto tiempo tenemos que crear un fichero nuevo
- **rollOnFileSizeLimit**: Indicamos si queremos poner un limite maximo de tamaño
- **fileSizeLimitBytes**: Si rellenamos esta opción, podemos indicar un nuevo maximo en `bytes` de tamaño del fichero.
- **restrictedToMinimumLevel**: Se almacenan los Logs a partir del nivel de log indicado.

## Base de Datos(MSSQL Server)
Guarda el proceso de Logging en una tabla de Base de Datos.
> En este ejemplo de hace uso de la Base de Datos Microsoft SQL Server y requiere del paquete `Serilog.Sinks.MSSqlServer`

```Csharp
WriteTo.MSSqlServer(
    connectionString: "Cadena de Conexion a Base de Datos",
    new MSSqlServerSinkOptions
    {
        SchemaName = "dbo",
        TableName = "Logs",
        AutoCreateSqlTable = true,
    },
    restrictedToMinimumLevel: LogEventLevel.Warning);
```
- **connectionString**: Indicamos la forma de conectar a la Base de Datos.
- **MSSqlServerSinkOptions**: Mandamos un objeto de configuración
    - **SchemaName**: Indicamos el nombre del Esquema donde esta ubicada la Tabla
    - **TableName**: Indicamos el nombre de la Tabla de Logs
    - **AutoCreateSqlTable**: Indicamos si queremos que se cree la tabla si no existiera.
- **restrictedToMinimumLevel**: Se almacenan los Logs a partir del nivel de log indicado.

## Greylog
Se pueden enviar los logs a un servicio externo configurado como `Greylog` para agregar observabilidad a nuestro desarrollo.
> Debemos instalar el paquete `Serilog.Sinks.Graylog`

```Csharp
var grayLogConfig = new GraylogSinkOptions
{
    HostnameOrAddress = "Ubicacion, por ejemplo, localhost",
    Port = 12201,

    TransportType = TransportType.Udp,
    MinimumLogEventLevel = LogEventLevel.Error,
};
loggerConfig.WriteTo.Graylog()
```

## Seq
Se pueden enviar los logs al servicio `Seq` para agregar observabilidad a nuestro desarrollo.
> Debemos instalar el paquete `Serilog.Sinks.Seq`

```Csharp
loggerConfig.WriteTo.Seq(hostContext.Configuration["ConnectionStrings:SeqConnectionString"]!, LogEventLevel.Information);
```
<img width="919" alt="image" src="https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/05364daf-d941-4980-bffa-313f15798455">

## Application Insights
- Instalamos `Serilog.Sinks.ApplicationInsights`

Por un lado tenemos que configurar ApplicationInsights, para ello tenemos poner el siguiente código

```Csharp
var applicationInsightsServiceOptions = new ApplicationInsightsServiceOptions()
{
};
services.AddApplicationInsightsTelemetry(applicationInsightsServiceOptions);
```
- Creamos un objeto de tipo `ApplicationInsightsServiceOptions`, que se utiliza para configurar ciertos comportamientos de la telemetria que va a coger
- Agregamos al servicio de dependencias el servicio de Insights Telemetry

```Csharp
var applicationInsightsConfig = serviceProvider.GetRequiredService<TelemetryConfiguration>();
config.WriteTo.ApplicationInsights(applicationInsightsConfig, TelemetryConverter.Traces);
```
- Para agregar el servicio de Insights con `Serilog` tenemos que obtener el objeto de configuracion de telemetria de insights

### Conexion con Insights
Para crear la conexion y enviar datos a Insights, necesitamos la `InstrumentationKey` si vamos a traves de Azure o la `ConnectionString`
Ambas se cogen de las variables de entorno o fichero de configuracion `Appsettings`

```Json
"ApplicationInsights": {
    "InstrumentationKey": "Instrumentation Key",
    "ConnectionString": "Copy connection string from Application Insights Resource Overview"
}
```
> De manera alternativa, se puede configurar la cadena de conexión en la variable de entorno APPLICATIONINSIGHTS_CONNECTION_STRING o ApplicationInsights:ConnectionString

> La libreria de insights es la que accede directamente a estos valores, si los tenemos parametrizados de otra forma, tendremos que asignarle los valores en la configuracion

### Visualizacion de Insights
He creado una prueba de concepto para mostrar como se visualizaria en Insights




## Almacenamiento de forma `Async`
Esta función se establece en la configuración antes de indicar el método de almacenamiento y recibe un `Action<LoggerSinkConfiguration>` para indicar como se deben mostrar/guardar la información`.

> Esta función realiza el guardado de información de manera asincrona, por tanto el guardado de Logs se realiza en segundo plano. Para hacer uso de ella, se requiere el paquete `Serilog.Sinks.Async`

```Csharp
loggerConfig.WriteTo.Async(config =>
{
    config.Console(restrictedToMinimumLevel: LogEventLevel.Information);
});
```

# Usar Serilog
Para hacer uso de Serilog debemos de establecer la configuración, crear el Logger y después hacer uso del mismo.

```Csharp
Log.Logger = new LoggerConfiguration()
    .WriteTo.Async(config =>
    {
        config.MSSqlServer(
            connectionString: connectionString,
            new MSSqlServerSinkOptions
            {
                SchemaName = "dbo",
                TableName = "Logs",
                AutoCreateSqlTable = true,
            },
            restrictedToMinimumLevel: LogEventLevel.Warning);

        config.File(@"Path\log.txt",
            rollingInterval: RollingInterval.Hour,
            rollOnFileSizeLimit: true,
            fileSizeLimitBytes: 2000,
            restrictedToMinimumLevel: LogEventLevel.Warning);

        config.Console(restrictedToMinimumLevel: LogEventLevel.Information);
    })
    .CreateLogger();

Log.Warning("Mensaje Warning {value}", valor);
```

# Serilog con DI
Para hacer uso del método `UseSerilog` necesitamos instalar el paquete `Serilog.AspNetCore` que se encargará de agregar las clases del servicio al contenedor de dependencias.

```Csharp
hostBuilder.UseSerilog((hostBuilderContext, loggerConfig) =>
{
    // Agregar configuracion explicada
});
```

Inyectamos la interfaz `ILogger<Clase>` que nos provee Microsoft

```Csharp
private readonly ILogger<Clase> _logger;

public LoggingRequestHandler(ILogger<Clase> logger)
{
    _logger = logger;
}

_logger.LogDebug("Valor a Guardar del log");
```


### Template con objetos complejos
A veces necesitamos logear todos los valores de un objeto. En vez de tener que andar serializando en JSON, podemos agregar un `@` cuando especificamos el nombre del campo y `Serilog` se encargara mejor de serializarlo.

```Csharp
var user = new User("Nombre", "Email@email.com");
_logger.LogInformation("Se ha creado el usuario: {@DatosCreacionUsuario}", user);
```
Esto, en el mensaje final, se ve como crea el parametro `DatosCreacionUsuario`, que contiene el objeto `user` y por tanto, a la hora de filtrar por los logs, podremos filtrar por los campos de este.

<img width="919" alt="image" src="https://github.com/g4rc1ss/ApuntesProgramacion/assets/28193994/463df373-c40f-47ad-8278-2b57eafd648a">
