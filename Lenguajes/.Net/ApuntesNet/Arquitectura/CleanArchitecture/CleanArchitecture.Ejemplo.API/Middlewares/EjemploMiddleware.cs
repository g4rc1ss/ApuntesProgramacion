namespace CleanArchitecture.Ejemplo.API.Middlewares;

public class EjemploMiddleware : IMiddleware
{
    private readonly ILogger<EjemploMiddleware> _logger;

    public EjemploMiddleware(ILogger<EjemploMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Lo que se ejecuta antes de la resolucion de la request
        using var memoryStream = new MemoryStream();
        var original = context.Response.Body;

        context.Response.Body = memoryStream;
        _logger.LogInformation($"Request Path {context.Request.Path.Value}");

        // La llamada a la siguiente ejecucion correspondiente del Middleware hasta que se resuelva la Request
        await next(context);

        // Lo que se ejecuta despues de la resolucion de la request
        memoryStream.Seek(0, SeekOrigin.Begin);
        var data = await new StreamReader(context.Response.Body).ReadToEndAsync();
        memoryStream.Seek(0, SeekOrigin.Begin);

        _logger.LogInformation($"Datos del Response {data}");
        await memoryStream.CopyToAsync(original);
        context.Response.Body = original;
    }
}
