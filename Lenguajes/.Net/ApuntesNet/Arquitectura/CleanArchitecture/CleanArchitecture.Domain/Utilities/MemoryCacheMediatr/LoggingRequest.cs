using MediatR;

namespace CleanArchitecture.Domain.Utilities.MemoryCacheMediatr
{
    public class LoggingRequest : IRequest
    {
        public string Log { get; set; }
        public object TipoLog { get; set; }
    }
}
