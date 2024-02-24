Es un ORM(Object Relational Mapper) creado por `Microsoft` encargado de crear las queries SQL para la Base de datos y mapear los resultados.

El funcionamiento de este **Framework** hace uso de la interfaz `IQueryable<T>` junto con la libreria `Linq` para generar la consulta `SQL`.

Entity Framework es compatible con diferentes [proveedores de bases de datos](https://docs.microsoft.com/es-es/ef/core/providers/).

# Implementacion de EF Core
Con EF Core, el acceso a datos se realiza mediante un modelo. Un modelo se compone de clases de entidad y un objeto de contexto que representa una sesión con la base de datos. Este objeto de contexto permite consultar y guardar datos.

EF admite los siguientes métodos de desarrollo de modelos:
- Generar un modelo a partir de una base de datos existente.
- Codificar un modelo manualmente para que coincida con la base de datos.
- Una vez creado un modelo, usar Migraciones de EF para crear una base de datos a partir del modelo. Migraciones permite que la base de datos evolucione a medida que el modelo va cambiando.

## DbContext
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

## EF Core con Dependency Injection
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

### AddDbContext
Al registrar el contexto usando esta opcion se creará un `DbContext` por cada **Request** y se eliminará cuando esta finalice.

```Csharp
services.AddDbContext<ContextoSqlServer>(options =>
{
    options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(ContextoSqlServer)));
});
```

Cuando no disponemos de un tiempo de vida `scoped` debemos de implementar el tipo `transient`, por ejemplo, cuando realizamos la DI en una aplicacion Desktop. Para ello tenemos que indicarlo en el metodo `AddDbContext` con los parametros `contextLifetime` y `optionsLifetime`

### AddDbContextPool
**Esta opción no se puede utilizar sin un entorno `scoped`**

Cuando nos llega una **Request**, se procesa y al finalizar se realiza un `Dispose` de todos los elementos, incluyendo los `DbContext` y por tanto son eliminados. 

**DbContextPool** sirve para reutilizar los contextos que van a ser eliminados en otras peticiones, de esa manera evitamos crear un `DbContext` cada vez.

> Las instancias de `DbContext` creadas mediante el Pool pueden ser `Disposed` puesto que cuando se ejecuta desactiva el objeto de forma que se puede volver a reutilizar para futuras ocasiones.

```Csharp
services.AddDbContextPool<ContextoSqlServer>(options =>
{
    options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(ContextoSqlServer)));
});
```

### AddDbContextFactory
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

### AddPooledDbContextFactory
Usando la factoria sin un objeto Pool, cada vez que creamos un contexto, lo usamos y lo eliminamos cuando no lo necesitemos.

Gracias a esta opcion, podremos ir reutilizando diferentes contextos creados en vez de ser directamente eliminados. Es un punto importante a valorar, puesto que puede suponer un aumento en el performance a la larga bastante considerable.

> Las instancias de `DbContext` creadas mediante el Pool pueden ser `Disposed` puesto que cuando se ejecuta desactiva el objeto de forma que se puede volver a reutilizar para futuras ocasiones.

```Csharp
services.AddPooledDbContextFactory<EjemploContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString(nameof(EjemploContext)));
});
services.AddScoped(p => p.GetRequiredService<IDbContextFactory<EjemploContext>>().CreateDbContext());
```
