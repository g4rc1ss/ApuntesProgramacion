using CleanArchitecture.Domain.Utilities.MemoryCacheMediatr;
using MediatR;

namespace CleanArchitecture.Ejemplo.API.Utilities
{
    public class LoggingRequestHandler : IRequestHandler<LoggingRequest>
    {

        public Task<Unit> Handle(LoggingRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
