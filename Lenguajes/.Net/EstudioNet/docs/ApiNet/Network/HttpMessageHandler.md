# Handler de Mensajes HTTP
Un handler de mensajes es una clase que recibe una solicitud HTTP y devuelve una respuesta HTTP. Los controladores de mensajes derivan de la clase `HttpMessageHandler` abstracta.

Normalmente, una serie de controladores de mensajes se encadenan juntas. El primer controlador recibe una solicitud HTTP, realiza algún procesamiento y proporciona la solicitud al siguiente controlador. En algún momento, se crea la respuesta y vuelve a la cadena. Este patrón se denomina **controlador de delegación**.

El método toma `HttpRequestMessage` como entrada y devuelve de forma asíncrona un `HttpResponseMessage`.
- Procesa el mensaje de solicitud.
- Llame `base.SendAsync` para enviar la solicitud al controlador interno.
- El controlador interno devuelve un mensaje de respuesta. (Este paso es **asíncrono**).
- Procesa la respuesta y la devuelve.


Para crear un handler, debemos de heredar de la clase `DelegatingHandler`o `HttpMessageHandler`, en la cual podemos sobreescribir el método `Send` o `SendAsync` para implementar nuestra lógica.
```Csharp
public class MessageHandler1 : DelegatingHandler
{
    protected async override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Debug.WriteLine("Process request");
        // Call the inner handler.
        var response = await base.SendAsync(request, cancellationToken);
        Debug.WriteLine("Process response");
        return response;
    }
}
```