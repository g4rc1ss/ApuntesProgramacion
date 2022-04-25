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
Necesitamos instalar el paquete nuget `Microsoft.Extensions.Caching.StackExchangeRedis`

Tenemos que registrar la dependencia.
```Csharp
builder.services.AddStackExchangeRedisCache(options =>
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

