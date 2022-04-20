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
