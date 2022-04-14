using CleanArchitecture.ApplicationCore.Domain.Utilities.MemoryCacheMediatr;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace CleanArchitecture.Ejemplo.Utilities
{
    public class MemoryCacheRequestHandler : IRequestHandler<MemoryCacheRequest, MemoryCacheResponse>
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheRequestHandler(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<MemoryCacheResponse> Handle(MemoryCacheRequest request, CancellationToken cancellationToken)
        {
            if (!_memoryCache.TryGetValue(request.Key, out var valueToReturn))
            {
                valueToReturn = _memoryCache.Set(request.Key, request.Value);
            }
            return Task.FromResult(new MemoryCacheResponse
            {
                Value = valueToReturn,
                Succeed = valueToReturn != null
            });
        }
    }
}
