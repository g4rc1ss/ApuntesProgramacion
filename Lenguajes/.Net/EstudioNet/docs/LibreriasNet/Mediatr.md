La libreria `Mediatr` se utiliza para implementar el Patron de Diseño mediator, que es utilizado principalmente para resolver las multiples dependencias entre objetos.

De esta manera obtendremos una aplicación mas desacoplada, limpia y sencilla de interpretar.

# Mediatr con Dependency Injection
Para poder agregar `Mediatr` al servicio de inyeccion de dependencias y poder hacer uso de su implementacion, en el archivo principal usaremos el metodo al cual tendremos que pasarle el Assembly que queremos leer.

```Csharp
services.AddMediatR(Assembly.GetExecutingAssembly());
```

Este método se encarga de leer mediante reflection el assembly o assemblies que le pasamos y busca las clases que implementan sus interfaces como `IRequestHandler`, `IRequest`, etc.

# Usar Mediatr
Para usar `MediatR` necesitamos:
- Una clase que implemente la interfaz `IMediatR<TRequest, TResponse>`
    ```Csharp
    public class ClaseRequestHandler : IRequestHandler<ClaseRequest, ClaseResponse>
        {
            public Task<ClaseResponse> Handle(ClaseRequest request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    ```
- Una clase que implemente la interfaz `IRequest<TResponse>`
    ```Csharp
    public class ClaseRequest : IRequest<ClaseResponse>
    {
        public object ObjetoEnviamosHandler { get; set; }
    }
    ```
- Una clase para la Response
    ```Csharp
    public class ClaseResponse
    {
        public object ObjetoRespondemos { get; set; }
    }
    ```

El proceso de llamada es el siguiente:

1. Inyectamos la interfaz `IMediatR`.
    ```Csharp
    private readonly IMediator _mediator;

    public Clase(IMediator mediator)
    {
        _mediator = mediator;
    }
    ```
1. Ejecutamos un método, como `Send()`, enviando como parametro una instancia de la clase Request.
    ```Csharp
    ClasResponse llamadaMediatr = await _mediator.Send(
        new ClaseRequest
        {
            ObjetoEnviamosHandler = null
        }
    );
    ```
1. La función de MediatR realiza una busqueda usando el tipo de la instancia que le pasamos para localizar su clase `RequestHandler` correspondiente y devuelve la instancia usando el inyector de dependencias.
1. Ejecuta el metodo `Handler` y devuelve la response.
    ```Csharp
    public class ClaseRequestHandler : IRequestHandler<ClaseRequest, ClaseResponse>
    {
        private readonly IMemoryCache _memoryCache;

        public ClaseRequestHandler(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<ClaseResponse> Handle(ClaseRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    ```
> Como se utiliza el inyector de dependencias para resolver la instancia de la clase `Handler`, en esta clase podemos aplicar la inyección de dependencias por constructor para usar librerias como el acceso a base de datos, etc.

# Funciones de Mediatr
Mediatr utiliza diferentes funciones para resolver la clase `Handler` dependiendo del uso que necesitemos.

- `Send`: Busca, resuelve y ejecuta un único Handler.
- `Publish`: Busca, resuelve y ejecuta múltiples Handler.
- `CreateStream`: Crea un Stream a traves de un único Handler.
