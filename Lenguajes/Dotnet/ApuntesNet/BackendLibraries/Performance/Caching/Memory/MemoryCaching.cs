using Caching.ObjCaching;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Caching.Memory;

internal class MemoryCaching
{
    private readonly IServiceProvider _serviceProvider;

    public MemoryCaching()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddMemoryCache();
        _serviceProvider = services.BuildServiceProvider();
    }

    public void MemoryCacheWithDI()
    {
        var memoryCache = _serviceProvider.GetRequiredService<IMemoryCache>();

        var timeStart = DateTime.Now.TimeOfDay;
        Console.WriteLine($"Obtenemos la lista {timeStart}");
        memoryCache.Set(ObjectsToCaching.cacheKey, ObjectsToCaching.listToCache, TimeSpan.FromMinutes(1));

        Console.WriteLine($"Obtenemos la lista {DateTime.Now.TimeOfDay}");

        if (memoryCache.TryGetValue<IEnumerable<int>>(ObjectsToCaching.cacheKey, out var listaCacheRecuperada))
        {
            listaCacheRecuperada.Select(x =>
            {
                Console.WriteLine(x);
                return x;
            }).ToList();
        }

        memoryCache.Remove(ObjectsToCaching.cacheKey);
    }
}
