using MediatR;

namespace CleanArchitecture.Domain.Utilities.MemoryCacheMediatr
{
    public class MemoryCacheRequest : IRequest<MemoryCacheResponse>
    {
        public string Key { get; set; }
        public object Value { get; set; }
    }
}
