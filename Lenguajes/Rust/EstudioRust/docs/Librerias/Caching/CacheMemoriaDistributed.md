# Cache en Memoria con IDistributedCache
La caché de memoria distribuida es una implementación proporcionada por el marco de `IDistributedCache` que almacena elementos en memoria. La caché de memoria distribuida no es una caché distribuida real.

> La clase que implementa la interfaz de `IDistributedCache` es `MemoryDistributedCache` que hace uso de la implementacion de `IMemoryCache`.

> La interfaz `IDistributedCache` es la que implementan todos los servicios de cache distribuida como `Redis`, `SQL Server`, etc. Por tanto, si tenemos pensado a futuro de realizar una implementacion de servidor de cache distribuido, debemos hacer uso de esta libreria.


## DistributedCache en contenedor de dependencias
Agregamos `DistributedCache` a la inyeccion de dependencias.
```Csharp
services.AddDistributedMemoryCache();
```

```Csharp
services.AddDistributedMemoryCache(options =>
{
    var clock = new Microsoft.Extensions.Internal.SystemClock();
    clock.UtcNow.AddHours(5);
    options.Clock = clock;
    options.CompactionPercentage = 20.0;
    options.SizeLimit = 2048; // 2gb
    options.ExpirationScanFrequency = new TimeSpan(2, 0, 0); // 2h
});
```
1. `Clock`: Indicamos la caducidad del elemento en cache pasandole una clase que implementa `ISystemClock`
1. `ExpirationScanFrequency`: Podemos indicar cada cuanto tiempo se debe de escanear cache caducada para ser eliminada de la memoria.
1. `SizeLimit`: Sirve para indicar el tamaño maximo del almacenamiento en caché
1. `CompactionPercentage`: Eliminar un porcentaje del contenido cuando se excede el limite de memoria establecido de caché.

## Usar DistributedCache
1. Importamos la dependencia `IDistributedCache` por constructor
1. Comprobamos si existe el dato en memoria enviando un identificador del contenido, si es asi, nos devuelve un objeto con el contenido
1. Si no existe el contenido, devuelve `null`, habra que comprobarlo.
```Csharp
private readonly IDistributedCache _distributedCache;

public CacheConstructor(IDistributedCache distributedCache)
{
    _distributedCache = distributedCache;
}

var result = await _distributedCache.GetStringAsync(Key, cancellationToken);
if (string.IsNullOrEmpty(result))
{
    await _distributedCache.SetStringAsync(Key, Value);
}
```

## DistributedCacheEntryOptions
1. `AbsoluteExpiration`: Podemos indicar una fecha de caducidad del elemento en cache
1. `AbsoluteExpirationRelativeToNow`: Podemos indicar cuánto tiempo va a durar la cache en memoria a partir de este momento
1. `SlidingExpiration`: Podemos indicar cuanto va a durar el elemento en cache una vez "borrado". El objeto seria marcado como `Inaccesible`.

```Csharp
var options = new DistributedCacheEntryOptions
{
    AbsoluteExpiration = DateTime.Now.AddDays(2),
    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(2),
    SlidingExpiration = TimeSpan.FromMinutes(5),
};
await _distributedCache.SetStringAsync(Key, Value, options);
```