using System.Text.Json;
using CleanArchitecture.Domain.Utilities.LoggingMediatr;
using MediatR;

namespace CleanArchitecture.Ejemplo.RazorPages.Utilities
{
    public class LoggingRequestHandler : INotificationHandler<LoggingRequest>
    {
        private readonly ILogger<LoggingRequestHandler> _logger;

        public LoggingRequestHandler(ILogger<LoggingRequestHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(LoggingRequest request, CancellationToken cancellationToken)
        {
            var log = JsonSerializer.Serialize(request.Log);
            switch (request.TipoLog)
            {
                case LogType.Debug:
                    _logger.LogDebug(log);
                    break;
                case LogType.Info:
                    _logger.LogInformation(log);
                    break;
                case LogType.Warning:
                    _logger.LogWarning(log);
                    break;
                case LogType.Error:
                    _logger.LogError(log);
                    break;
                default:
                    break;
            }
            return Task.CompletedTask;
        }
    }
}
