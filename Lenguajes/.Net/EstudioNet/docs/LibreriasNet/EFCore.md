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

```Csharp
services.AddPooledDbContextFactory<EjemploContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString(nameof(EjemploContext)));
});
services.AddScoped(p => p.GetRequiredService<IDbContextFactory<EjemploContext>>().CreateDbContext());
```

# Ejecucion de Consultas
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

## Consulta
Cuando llama a los operadores LINQ, simplemente crea una representación de la consulta en memoria. La consulta solo se envía a la base de datos cuando se usan los resultados.

Las operaciones más comunes que generan que la consulta se envíe a la base de datos son:

- La iteración de los resultados en un bucle for
- Uso de operadores como ToList, ToArray, Single y Count, o sobrecargas asincrónicas equivalentes

### Consultar todos los registros
```Csharp
from usuario in context.Usuarios
select usuario

await context.Usuarios.ToListAsync();
```

### Where
```Csharp
from usuario in context.Usuarios
where usuario.Edad < 22
select usuario

context.Usuarios.Where(x => x.Edad < 22);
```

### Order By
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

### Join
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

### Group By
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

## Guardado
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

# Migrations
Con el tiempo vamos aplicando las aplicaciones y realizamos modificaciones en la base de datos, por ejemplo, agregamos tablas/entidades, campos, modificamos el esquema, etc. Para poder tener todo eso sincronizado se usan las migraciones.

A nivel general, las migraciones funcionan de esta forma:
- EF Core compara el modelo modificado con una instantánea del anterior para determinar las diferencias y genera los archivos de origen de la migración, de los que se puede realizar el seguimiento en el control de código fuente del proyecto como cualquier otro archivo de código fuente.
- Una vez que se ha generado una migración nueva, hay varias maneras de aplicarla a una base de datos. EF Core registra todas las migraciones aplicadas en una tabla de historial especial, lo que le permite saber qué migraciones se han aplicado y cuáles no.

## Code First
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

### Configurando las relaciones en las entidades
Cuando queremos hacer la base de datos a traves de `Code First` debemos de configurar las relaciones de las tablas y los navegadores de forma manual en las clases de entidades.

Por un lado tenemos los campos de claves foraneas, que son las columnas que, mediante un campo(id generalmente) se relacionan con otras tablas. Dependiendo de la relacion que tengan las tablas, la Clave Foranea se movera a una tabla u otra:
- `1:1`: Cualquiera de las dos debe de tener la clave foranea 
- `1:N`: La clave foranea se traslada en el sentido de la N
- `N:M`: Estas relaciones generan una nueva tabla que contiene las dos claves foraneas de las tablas que relaciona.

Esto trasladado a entidades de EF Core:
- **1:1** Suponiendo dos tablas, una tabla **Propiedad** y otra tabla **PropiedadDetalle**, 1 propiedad contiene 1 Detalle y un detalle de propiedad es 1 propiedad. La relacion se realiza de la siguiente forma
    - Señalamos las claves foraneas, en este caso tiene una relacion con **PropiedadDetalleId**
    - Creamos los navegadores
    ```Csharp
    public class Propiedad 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        // Claves Foraneas
        public string PropiedadDetalleId { get; set; }

        // Navegadores
        public PropiedadDetalle PropiedadDetalleNavigation { get; set; }
    }
    ```
    - Creamos los campos de PropiedadDetalle
    ```Csharp
    public class PropiedadDetalle 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
    }
    ```

- **1:N** Suponiendo una tabla llamada **PropiedadDetalle** y otra llamada **Imagen**, 1 propiedad puede contener 1 o varias Imagenes y 1 imagen solo puede pertenecer a 1 propiedad. En esta relación la clave foranea se mueve en direccion a la N, por tanto, `Imagen` contendra la clave de `PropiedadDetalle`
    - Creamos un objeto Navegador, porque aunque no tenga una clave Foranea, una Propiedad tiene una coleccion de Imagenes y se puede agregar en EF Core esta relacion, de esta forma, cuando se haga una consulta, el framework mapeara la lista de imagenes si queremos.
    ```Csharp
    public class PropiedadDetalle 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        // Claves Foraneas
        public string TipoPropiedadId { get; set; }

        // Navegadores
        public IEnumerable<Imagen> ImagenesPropiedadDetalleNavigation { get; set; }
    }
    ```
    - Indicamos la clave foranea en la Entidad `Imagen`
    - Creamos un objeto navigation para poder acceder directamente a la propiedad en una query a `PropiedadDetalle`
    ```Csharp
    public class Imagen 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        //Claves Foraneas
        public string PropiedadDetalleId { get; set; }

        // Navegadores
        public PropiedadDetalle PropiedadDetalleNavigation { get; set; }
    }
    ```

- **N:M** Suponiendo dos tablas, una **Propiedad** y otra **Usuario**, queremos hacer que un usuario pueda establecer como favorito una propiedad, por tanto 1 usuario puede establecer 1 o varias propiedades como favorito y una propiedad puede tener 1 o varios usuarios de favoritos, por tanto tenemos una relacion N:M. Como hemos dicho arriba, la relacion N:M generan tabla, por tanto la tabla `Favorito`.
    - La entidad `Propiedad` contiene un objeto navegacion para poder obtener una lista de los usuarios que tienen marcada esa propiedad como favorito, pero no tiene ninguna clave foranea
    ```Csharp
    public class Propiedad 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        // Claves Foraneas
        public string PropiedadDetalleId { get; set; }

        // Navegadores
        public ICollection<Favorito> FavoriteNavigation { get; set; }
    }
    ```
    - La clase usuario agregamos un objeto Navigation para poder obtener la lista de propiedades marcadas como favorito por 1 usuario, pero este no tiene la clave foranea
    ```Csharp
    public class User : IdentityUser<int> 
    {
        //Navigation
        public ICollection<Favorito> FavoritePropertyNavigation { get; set; }
    }
    ```
    - Como las relaciones N:M generan tabla, tenemos la tabla Favorito, que contiene las claves Foraneas de UserId y PropiedadId, que estas dos conjuntas son la key principal.
    - Tambien asignamos los navegadores para, teniendo un registro de favorito, poder buscar el Usuario y la Propiedad vinculada.
    ```Csharp
    public class Favorito 
    {
        public int UserId { get; set; }
        public string PropiedadId { get; set; }

        // Navegadores
        public User UserNavigation { get; set; }
        public Propiedad PropiedadNavigation { get; set; }
    }
    ```
    - En este caso, en el `ModelBuilder` habra que indicar que la tabla Favoritos contiene las 2 key, con la key principal, para ello ponemos lo siguiente
    ```Csharp
    builder.Entity<Favorito>()
        .HasKey(fav => new {
            fav.UserId,
            fav.PropiedadId
        });
    ```

# Database First
Cuando preferimos crear la base de datos manualmente o ya la tenemos creada, por ejemplo, porque implementamos EF core en un proyecto que ya estaba creado, podemos hacer uso de un comando que nos crea todas las entidades con sus relaciones y el contexto ya configurado.

1. En el comando se agrega la cadena de conexion para mapear la base de datos y las relaciones
1. Indicamos el paquete Nuget que indica el tipo de base de datos al cual se va a conectar, en el ejemplo `Microsoft.EntityFrameworkCore.SqlServer`
1. La opcion `-Project` se usa porque debemos de ejecutar el comnado referenciando al proyecto que contiene `Microsoft.EntityFrameworkCore.Design`, pero puede que se quieran crear el contexto y las entidades a utilizar en otro proyecto, por ejemplo, en el proyecto de `Dominio`.

```powershell
# Visual studio
Scaffold-DbContext "Cadena de Conexion" Microsoft.EntityFrameworkCore.SqlServer -Project "Nombre.de.proyecto" -Force
```

Despues de tener los archivos de entidades y contexto creados, tendremos que echar un vistazo a la configuracion del `ModelBuilder` y del contexto, por ejemplo, en el DbContext seguramente tendremos que eliminar el metodo `OnConfiguring()`.

# Crear migrations en otro proyecto
Si queremos tener las migraciones en otro proyecto, sea por organizacion o porque queremos crear un proyecto para aplicar las migraciones por ejemplo, podemos hacerlo agregando la opcion en la configuración del contexto de la siguiente forma.

```Csharp
options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(EjemploContext)), sql =>
{
    sql.MigrationsAssembly(typeof(Program).Assembly.FullName);
});
```
