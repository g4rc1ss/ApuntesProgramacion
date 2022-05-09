using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cachear.ObjCaching;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Cachear.Memory
{
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
            var _memoryCache = _serviceProvider.GetRequiredService<IMemoryCache>();

            var timeStart = DateTime.Now.TimeOfDay;
            Console.WriteLine($"Obtenemos la lista {timeStart}");
            _memoryCache.Set(ObjectsToCaching.cacheKey, ObjectsToCaching.listToCache, TimeSpan.FromMinutes(1));

            Console.WriteLine($"Obtenemos la lista {DateTime.Now.TimeOfDay}");

            if (_memoryCache.TryGetValue<IEnumerable<int>>(ObjectsToCaching.cacheKey, out var listaCacheRecuperada))
            {
                listaCacheRecuperada.Select(x =>
                {
                    Console.WriteLine(x);
                    return x;
                }).ToList();
            }

            _memoryCache.Remove(ObjectsToCaching.cacheKey);
        }
    }
}
