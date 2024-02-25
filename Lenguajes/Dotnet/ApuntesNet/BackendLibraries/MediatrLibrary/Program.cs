using MediatR;

using MediatrLibrary;
using MediatrLibrary.Handlers.PublishMethod;
using MediatrLibrary.Handlers.SendMethod;

using Microsoft.Extensions.DependencyInjection;

var serviceProvider = Helper.GetServiceProvider();
var mediatr = serviceProvider.GetRequiredService<IMediator>();

await mediatr.Publish(new PublishMethodRequest
{
    Message = "Prueba de notificacion por el metodo Publish con Mediatr"
});

var respuesta = await mediatr.Send(new SendMethodRequest
{
    Message = "Prueba de envio de mensaje a un handler de mediator"
});

Console.WriteLine(respuesta.Respuesta);


Console.WriteLine("Pulsa una tecla para terminar...");
Console.Read();
