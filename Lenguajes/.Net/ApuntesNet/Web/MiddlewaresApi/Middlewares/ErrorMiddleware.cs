using System.Text.Json;

namespace MiddlewaresApi.Middlewares
{
    public class ErrorMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorMiddleware> _logger;

        public ErrorMiddleware(ILogger<ErrorMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var messageResponse = new
                {
                    Detalle = ex.Message,
                    StackTrace = ex.StackTrace,
                };

                await context.Response.WriteAsJsonAsync(messageResponse);
            }
        }
    }
}
