# Serilog
Librería que automatiza el proceso de logs, pudiendo ser configurada para guardar la información en diferentes espacios de almacenamiento como Archivos, Bases de Datos, etc.

# Configurar Serilog
La configuración se realiza a traves de la clase `LoggerConfiguration` 

## Logs en Consola
Muestra el proceso de `logging` en la interfaz de la Consola, es buena opción para un entorno de desarrollo.

```Csharp
WriteTo.Console()
```

## Logs en Archivos de Texto
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

## Logs en Base de Datos
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

## Logs en Greylog
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

## Logs en Seq
Se pueden enviar los logs al servicio`Seq` para agregar observabilidad a nuestro desarrollo.
> Debemos instalar el paquete `Serilog.Sinks.Seq`

```Csharp
loggerConfig.WriteTo.Seq(hostContext.Configuration["ConnectionStrings:SeqConnectionString"]!, LogEventLevel.Information);
```

## Almacenamiento de forma `Async`
Esta función se establece en la configuración antes de indicar el método de almacenamiento y recibe un `Action<LoggerSinkConfiguration>` para indicar como se deben mostrar/guardar la información`.

> Esta función realiza el guardado de información de manera asincrona, por tanto el guardado de Logs se realiza en segundo plano. Para hacer uso de ella, se requiere el paquete `Serilog.Sinks.Async`

```Csharp
loggerConfig.WriteTo.Async(config =>
{
    config.Console(restrictedToMinimumLevel: LogEventLevel.Information);
});
```

## Configurando la Inyeccion de Dependencias
Para hacer uso del método `UseSerilog` necesitamos instalar el paquete `Serilog.AspNetCore` que se encargará de agregar las clases del servicio al contenedor de dependencias.

```Csharp
hostBuilder.UseSerilog((hostBuilderContext, loggerConfig) =>
{
    // Agregar configuracion explicada
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

Log.Warning("Mensaje Warning {0}", valor);
```

## Usar Serilog con Inyeccion de Dependencias
Se puede hacer uso de Serilog mediante la Inyeccion de Dependencias. Para ello debemos de establecer la configuración como esta explicado y debemos usar la interfaz `ILogger<Clase>` del paquete de Microsoft.

```Csharp
private readonly ILogger<Clase> _logger;

public LoggingRequestHandler(ILogger<Clase> logger)
{
    _logger = logger;
}

_logger.LogDebug("Valor a Guardar del log");
```
