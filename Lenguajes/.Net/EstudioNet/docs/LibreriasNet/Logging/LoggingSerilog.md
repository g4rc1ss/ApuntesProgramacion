# Serilog


# Configurar Serilog

```Csharp
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Warning()
    .WriteTo.Async(config =>
    {
        // Configuramos que los logs se guarden en Base de datos SQL Server
        config.MSSqlServer(
            connectionString: connectionString,
            new MSSqlServerSinkOptions
            {
                SchemaName = "dbo",
                TableName = "Logs",
                AutoCreateSqlTable = true,
            },
            restrictedToMinimumLevel: LogEventLevel.Warning);
        
        // Configuramos los logs por consola de tipo informacion
        config.File("Path/log.txt",
            rollingInterval: RollingInterval.Day,
            rollOnFileSizeLimit: true, 
            restrictedToMinimumLevel: LogEventLevel.Warning);

        // Configuramos los logs por consola de tipo informacion
        config.Console(restrictedToMinimumLevel: LogEventLevel.Information);
    })
    .CreateLogger();
```

# Serilog con Inyeccion de Dependencias
Para hacer uso del método `UseSerilog` necesitamos instalar el paquete `Serilog.AspNetCore` que se encargará de agregar las clases del servicio al contenedor de dependencias.

```Csharp
hostBuilder.UseSerilog((hostBuilderContext, loggerConfig) =>
{
    loggerConfig.WriteTo.Async(config =>
    {
        // Configuramos que los logs se guarden en Base de datos SQL Server
        config.MSSqlServer(
            connectionString: connectionString,
            new MSSqlServerSinkOptions
            {
                SchemaName = "dbo",
                TableName = "Logs",
                AutoCreateSqlTable = true,
            },
            restrictedToMinimumLevel: LogEventLevel.Warning);
        
        // Configuramos los logs por consola de tipo informacion
        config.File("Path/log.txt",
            rollingInterval: RollingInterval.Day,
            rollOnFileSizeLimit: true, 
            restrictedToMinimumLevel: LogEventLevel.Warning);

        // Configuramos los logs por consola de tipo informacion
        config.Console(restrictedToMinimumLevel: LogEventLevel.Information);
    });
});
```

# Usar Serilog