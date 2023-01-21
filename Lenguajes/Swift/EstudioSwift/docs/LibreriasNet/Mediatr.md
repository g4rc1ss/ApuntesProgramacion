La libreria `Mediatr` se utiliza para implementar el Patron de Diseño mediator, que es utilizado principalmente para resolver las multiples dependencias entre objetos.

De esta manera obtendremos una aplicación mas desacoplada, limpia y sencilla de interpretar.

# Mediatr con Dependency Injection
Para poder agregar `Mediatr` al servicio de inyeccion de dependencias y poder hacer uso de su implementacion, en el archivo principal usaremos el metodo al cual tendremos que pasarle el Assembly que queremos leer.

```Csharp
services.AddMediatR(Assembly.GetExecutingAssembly());
```

Este método se encarga de leer mediante reflection el assembly o assemblies que le pasamos y busca las clases que implementan sus interfaces como `IRequestHandler`, `IRequest`, etc.

# Mediator RequestHandler
Con Mediator podemos hacer uso del metodo `Send()` para resolver la dependencia de una clase que implemente la interfaz `IRequestHandler<TRequest, TResponse>`.

Para registrar un servicio de mediator de esta forma necesitaremos:
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

# Mediator Notification
Con Mediator podemos hacer uso del metodo `Publish()` para enviar el objeto request a una o varias dependencias registradas en `Mediatr`

Para registrar un servicio de mediator de esta forma necesitaremos:
- Una o varias clases que implementen la interfaz `INotificationHandler<TRequest>`
    ```Csharp
    internal class PublishMethodOneNotificationHandler : INotificationHandler<PublishMethodRequest>
    {
        public Task Handle(PublishMethodRequest notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"El metodo PUBLISH 1 indica: {notification.Message}");
            return Task.CompletedTask;
        }
    }
    ```
- Una clase que implemente la interfaz `IRequest<TResponse>`
    ```Csharp
    internal class PublishMethodRequest : INotification
    {
        public string Message { get; set; }
    }
    ```


# Llamar a Mediator
El proceso de llamada es el siguiente:

1. Inyectamos la interfaz `IMediator`.
    ```Csharp
    private readonly IMediator _mediator;

    public Clase(IMediator mediator)
    {
        _mediator = mediator;
    }
    ```

1. Si queremos resolver clases del tipo `INotificationHandler` debemos usar el método `Publish`
    ```Csharp
    await mediatr.Publish(new PublishMethodRequest
    {
        Message = "Prueba de notificacion por el metodo Publish con Mediatr"
    });
1. Si queremos resolver una clase de tipo `IRequestHandler` se usará el metodo `Send`
    ```Csharp
    var respuesta = await mediatr.Send(new SendMethodRequest
    {
        Message = "Prueba de envio de mensaje a un handler de mediator"
    });
    ```
> Como se utiliza el inyector de dependencias para resolver la instancia de la clase `Handler`, en esta clase podemos aplicar la inyección de dependencias por constructor para usar librerias como el acceso a base de datos, etc.

