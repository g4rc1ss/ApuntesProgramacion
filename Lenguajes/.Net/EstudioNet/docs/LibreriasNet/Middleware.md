Un Middleware es una clase que permite manipular una peticion o respuesta HTTP

El proceso de ejecución de un Middleware se realiza cuando llega la `Request`, se pasan por los distintos Middlewares hasta ejecutar el proceso principal de la peticion y cuando este proceso devuelve el response, se pasa por los Middleare en sentido opuesto hasta que salga la peticion hacia el usuario.

![image](https://user-images.githubusercontent.com/28193994/147764665-091176bb-811a-43be-b010-980a94df5b3a.png)

Cabe destacar que el orden es importante, ya que como he indicado se van ejecutando uno detrás de otro. 

Hay que tener en cuenta, que podemos crear un middleware que en ciertas condiciones nos crea una respuesta directamente, esta acción lo que haría sería evitar que los middleware que vienen después no se ejecuten. 

# Crear un Middleware
Para crear un Middleware necesitamos implementar la interfaz `IMiddleware` que nos creara el metodo `Task InvokeAsync(HttpContext context, RequestDelegate next)`
1. La función `InvokeAsync` recibe el `HttpContext` y el `RequestDelegate`
    1. `HttpContext` contiene todos los datos de la peticion, tanto el `Request` como el `Response` entre otras cosas.
    1. `RequestDelegate` contiene el siguiente middleware a ejecutar, si no hay ningun Middleware mas, se pasará a ejecutar el proceso principal de la petición

1. La ejecución del Middleware funciona de la siguiente forma.
    1. Ejecutamos codigo antes de la ejecucion del proceso principal y el resto de Middlewares.
    1. Ejecutamos la función `await next(context);`. Este delegado pasa al siguiente Middleware sucesivamente hasta el proceso principal de la petición(la lógica de negocio).
    1. Cuando el proceso del delegado anterior termina, se ejecuta el codigo que queremos realizar despues de la petición.  
    Una vez finalizada la función se iran pasando a los anteriores Middlewares hasta que se devuelva la petición al usuario que solicito la Request.

```Csharp
public class EjemploMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Request

        // Ejecucion del resto de Middlewares
        await next(context);
        
        // Response
    }
}
```
Para implementarlo
1. Con el objeto de tipo `WebApplication`, que implementa la interfaz `IApplicationBuilder` podremos tener acceso al metodo `UseMiddleware<EjemploMiddleware>()`.

```csharp
builder.Services.AddScoped<EjemploMiddleware>();
app.UseMiddleware<EjemploMiddleware>();
```
