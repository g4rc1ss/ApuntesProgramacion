# IMemoryCache
El almacenamiento en caché es una técnica que tiene como objetivo mejorar el rendimiento y la escalabilidad de un sistema. Para ello, se copian temporalmente los datos a los que se accede con mayor frecuencia en memoria.

Podemos suponer un conjunto de usuarios que realizan las mismas peticiones para obtener los mismos resultados, por ejemplo, un listado de empresas.

El conjunto de usuarios tienen que realizar la misma peticion, eso provoca mas carga en el servidor de consulta o Base de datos para obtener lo mismo.
![image](https://user-images.githubusercontent.com/28193994/147925007-39b74663-47b8-41dc-bf44-b1d37fca5661.png)

Gracias al uso de la cache, podemos evitar tantas llamadas de la siguiente forma:
![image](https://user-images.githubusercontent.com/28193994/147925051-2c9fffb8-4f6b-4da2-b952-29218ac292fb.png)
1. El primer usuario que conecta, hace la peticion a la base de datos/servidor, etc. Y almacena en caché el resultado obtenido.
1. Cuando el resto de usuarios realizan la peticion, comprueban si el resultado esta almacenado en cache y si es asi, lo obtienen y sino, pues tienen que hacer la consulta de nuevo.

![image](https://user-images.githubusercontent.com/28193994/147925017-27db6cff-4b28-435e-b043-72481313180d.png)

## MemoryCacheOptions
1. `Clock`: Indicamos la caducidad del elemento en cache pasandole una clase que implementa `ISystemClock`
1. `ExpirationScanFrequency`: Podemos indicar cada cuanto tiempo se debe de escanear cache caducada para ser eliminada de la memoria.
1. `SizeLimit`: Sirve para indicar el tamaño maximo del almacenamiento en caché
1. `CompactionPercentage`: Eliminar un porcentaje del contenido cuando se excede el limite de memoria establecido de caché.

Agregamos `MemoryCache` a la inyeccion de dependencias.
```Csharp
builder.services.AddMemoryCache();
```

Memory cache con opciones de configuracion
```Csharp
builder.services.AddMemoryCache(options =>
{
    var clock = new Microsoft.Extensions.Internal.SystemClock();
    clock.UtcNow.AddHours(5);
    options.Clock = clock;
    options.CompactionPercentage = 20.0;
    options.SizeLimit = 2048; // 2gb
    options.ExpirationScanFrequency = new TimeSpan(2, 0, 0); // 2h
});
```

## Usar MemoryCache
1. Importamos la dependencia `IMemoryCache` por constructor
1. Comprobamos si existe el dato en memoria enviando un identificador del contenido, si es asi, nos devuelve un objeto rellenado con el contenido
1. Si no existe el contenido, devuelve false, obtenemos el contenido de otra forma y registramos el objeto en cache.
```Csharp
private readonly IMemoryCache _memoryCache;
public Constructor(IMemoryCache memoryCache)
{
    _memoryCache = memoryCache;
}

if (!_memoryCache.TryGetValue<TipoSerializacion>("Identificador", out var objetoSerializado))
{
    var objetoRegistrar = new TipoSerializacion();
    _memoryCache.Set("Identificador", objetoRegistrar);
}
```
