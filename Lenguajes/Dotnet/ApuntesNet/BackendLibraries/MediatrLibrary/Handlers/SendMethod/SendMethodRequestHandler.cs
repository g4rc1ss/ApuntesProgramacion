using MediatR;

namespace MediatrLibrary.Handlers.SendMethod
{
    internal class SendMethodRequestHandler : IRequestHandler<SendMethodRequest, SendMethodResponse>
    {
        private readonly IMediator _mediator;

        public SendMethodRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<SendMethodResponse> Handle(SendMethodRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"El metodo SEND indica: {request.Message}");

            return Task.FromResult(new SendMethodResponse
            {
                Respuesta = "Tarea completada y eso"
            });
        }
    }
}
