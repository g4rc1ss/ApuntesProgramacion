A menudo necesitamos convertir un tipo de objeto `A` en otro tipo `B` diferente para ser enviado a traves de capas de aplicacion, devolver los datos que necesitamos a un usuario, etc. AutoMapper se encarga de esa tarea tediosa pasando sus datos de forma automatizada haciendo uso del API `System.Reflection` para ello.


# MapperConfig
Para convertir un objeto es necesario configurar antes el mapeo que vamos a relizar, indicando los tipos y si fuera necesario, podriamos indicar propiedades con diferentes nombres.

```Csharp
var mapperConfig = new MapperConfiguration(x =>
{
    x.CreateMap<Object1, Object2>();
});

IMapper mapper = mapperConfig.CreateMapper();
```

## Mapear objetos con propiedades de distinto nombre
Cuando queremos convertir un objeto a otro, muchas veces pasa que tenemos nombres diferentes en las clases para referirse al mismo contenido. Para ello podemos configurar el mapeo de los tipos y vincular las propiedades que necesitamos.

```Csharp
CreateMap<Class1, Class2>()
    .ForMember(x => x.NombreUsuario, y => y.MapFrom(x => x.UserName))
    .ForMember(x => x.TieneDobleFactor, y => y.MapFrom(x => x.TwoFactorEnabled))
```

## Mapear un objeto simple a uno complejo
Si queremos mapear un objeto simple, como un `int` a un objeto mas complejo, como una clase, podemos indicarlo de la siguiente manera.

```Csharp
CreateMap<int, FiltroUser>()
    .ForMember(x => x.IdUsuario, y => y.MapFrom(x => x));
```

## Mapear objetos con acciones añadidas
Muchas veces queremos realizar alguna accion al hacer el mapeo, por ejemplo, sumar valores, realizar conversion de datos, concatenar cademas, etc. Para poder indicar acciones podemos realizar lo siguiente.

```Csharp
CreateMap<RequestLog, RequestLogResponse>()
    .ForMember(x => x.Mensaje, x => x.MapFrom(y => y.EsquemaPeticion))
    .BeforeMap((request, response) =>
    {
        response.TiempoTotal = (request.HoraFin - request.HoraInicio).TotalMilliseconds.ToString();
    });
```

# AutoMapper con Dependency Injection
Podemos agregar `AutoMapper` al contenedor de dependencias para que busque la configuración de los mapeos directamente en los assembles que indiquemos.

```Csharp
// Indicando un tipo
builder.Services.AddAutoMapper(typeof(Program));

// Indicando todos los Assemblies del proyecto
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
```
Como parámetro tenemos que enviar el Assembly o Assemblies donde están ubicados los archivos de configuración del Mapeo para que los busque y los cargue al contendor de dependencias.

## Profiles en AutoMapper
Los Profiles son archivos que se localizan a traves del inyector de dependencias y contienen la configuración y los mapeos disponibles.

```Csharp
public class ProfileAutoMapper : Profile
{
    public ProfileAutoMapper()
    {
        CreateMap<Object1, Object2>();
    }
}
```

# Funciones de Mapeo
Para realizar el proceso de mapeo se hace uso del método `Map` de la interfaz `IMapper`, para ello podemos inyectar mediante el contenedor de dependencias dicha interfaz o bien, crear la configuración y el objeto Mapper correspondiente.

```Csharp
_mapper.Map<Class1>(objToMap);
```

Podemos sobrecargar el metodo `Map` pasandole dos objetos para realizar mapeo entre ellos.

```Csharp
_mapper.Map<Type1, Type2>(objectToRead, objectToWrite);
```
>Recordar que se puede pasar la referencia `this` para pasarle el objeto en el que estas actualmente, de esta forma, podemos usar nuestra propia clase para ser mapeada, un ejemplo de uso puede ser en el caso de aplicaciones Desktop, como WPF, para rellenar valores de una respuesta en campos visuales.

# Buenas Practicas
- Hacer uso de la inyeccion de dependencias para el escaneo y registro de las configuraciones del perfil.
- Siempre organizar las configuraciones dentro de Profiles para poder tener varios archivos destinados a la configuración y de esta forma, ser mas claro y mantenible.
- Utilizar las expresiones LINQ para realizar las configuraciones, puesto que proporcionan mas performance.
- Simplificar y no hacer complejas las clases para realizar los mapeos
- No llamar a `CreateMap()` en cada uso. La configuración debe realizarse una sola vez.
- No realizar mapeos complejos, si es necesario, intentar evitar el uso de AutoMapper, puesto que **puede afectar significativamente al rendimiento**.
- Debemos centrar a AutoMapper solamente al mapeo, **no** realizar lógica de acciones en el.
- Evitar las referencias circulares de tipos, aunque AutoMapper los acepte, es probable que afecte en gran medida al rendimiento.