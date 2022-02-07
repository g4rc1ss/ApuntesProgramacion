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

# IMemoryCache
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

# IDistributedCache
El uso de cache distribuida consiste en tener uno o varios servidores dedicados al almacenamiento en cache de los objetos.

Hay varios motivos por lo que se puede ralizar esta tecnica, algunas de ellas son:
- Tenemos varios microservicios y no queremos duplicar el mismo almacenamiento, una forma de centralizar este tipo de almacenamiento
- Manejamos un volumen de peticiones elevado y queremos separar el gasto de recursos de memoria en otro servidor, para que no se vea excesivamente afectada la memoria del servidor principal
- Para mejorar la escalabilidad de la aplicacion, sobretodo si esta ubicada en una granja de servidores

## Redis
Un software de codigo abierto que nos permite almacenar en memoria estructuras de datos, capas de cache, etc.

A diferencia de lo visto anteriormente, Redis es una aplicacion que, por normal general, se suele instalar en un servidor de forma independiente.

La informacion de Redis se almacena en la memoria RAM, asique hay que tener en cuenta que tendremos que tener una cantidad elevada de ese tipo de memoria, no en el disco de forma persistente. 

### Implementar un servidor Redis
Como algo rapido, se puede crear el servidor redis directamente don un `docker-compose`, asique podemos crear las siguiente configuracion:

```docker
version: '2'
services:
  redis:
    image: 'bitnami/redis:latest'
    ports:
      - 6379:6379
    environment:
      - REDIS_PASSWORD=password123
```

### Redis en .Net
Necesitamos instalar el paquete nuget `Microsoft.Extensions.Caching.Redis`

Tenemos que registrar la dependencia.
```Csharp
builder.services.AddDistributedRedisCache(options =>
{
    options.Configuration = "localhost:6379,password=password123";
    options.InstanceName = "localhost";
});
```

- Importamos por constructor la dependencia de cache distribuida
```Csharp
private readonly IDistributedCache _distributedCache;

public Constructor(IDistributedCache distributedCache)
{
    _distributedCache = distributedCache;
}
```

- `SetStringAsync`: Enviamos el contenido a almacenar en el servidor cache, si el contenido existe, lo actualizara. 
- `GetStringAsync`: Obtenemos el objeto serializado en string del servidor.
- `RefreshAsync`: Actualiza el valor de la cache en funcion de la key que le pasamos y reinicia su tiempo de vida.
- `RemoveAsync`: Eliminamos el objeto guardado en cache.

