using MediatR;

namespace CleanArchitecture.ApplicationCore.Domain.Utilities.MemoryCacheMediatr
{
    public class MemoryCacheRequest : IRequest<MemoryCacheResponse>
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
