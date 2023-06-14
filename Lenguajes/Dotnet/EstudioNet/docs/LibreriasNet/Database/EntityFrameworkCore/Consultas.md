# Ejecución de Consultas
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

### Include
Entity Framework provee del metodo `Include()` para obtener el objeto `Navigation` que indiquemos y podemos ir ramificandolo con el método `ThenInclude()`.

Con esta funcion, EntityFramework analiza la relacion y crea una `INNER JOIN` o lo que considere necesario para devolver los datos.

> Es importante indicar que muchas veces sin indicar de manera explicita que queremos obtener los objetos `Navigation`, por ejemplo usando una consulta como `Context.Entidad.ToList()`, si que nos devuelve las relaciones, eso es porque EntityFramework cache las respuestas de las consultas anteriores durante un periodo de tiempo y si coincide, se mapean, pero no siempre puede pasar que lo haga, si se necesita si o si una consulta relacionada, hay que indicarlo de forma explicita.

```Csharp
Contexto.Entidad
    .Include(x => x.PropiedadNavigation)
    .ThenInclude(x => x.PropiedadNavegacionDePropiedadNavigation)
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

