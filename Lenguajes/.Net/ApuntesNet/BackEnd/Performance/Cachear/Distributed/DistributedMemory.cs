using System.Text.Json;
using Cachear.ObjCaching;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace Cachear.Distributed
{
    internal class DistributedMemory
    {
        private readonly IDistributedCache _distributedCache;

        public DistributedMemory()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddDistributedMemoryCache();
            var serviceProvider = services.BuildServiceProvider();
            _distributedCache = serviceProvider.GetRequiredService<IDistributedCache>();
        }

        public async Task DistributedMemoryWithDIAsync()
        {
            var listaSerializada = JsonSerializer.Serialize(ObjectsToCaching.listToCache);

            await _distributedCache.SetStringAsync(ObjectsToCaching.cacheKey, listaSerializada);


            var listaSerializadaRecuperada = await _distributedCache.GetStringAsync(ObjectsToCaching.cacheKey);
            var listaCacheRecuperada = JsonSerializer.Deserialize<IEnumerable<int>>(listaSerializadaRecuperada)!;

            if (listaSerializadaRecuperada.Count() > 0)
            {
                listaCacheRecuperada.Select(x =>
                {
                    Console.WriteLine(x);
                    return x;
                }).ToList();
            }
            _distributedCache.Remove(ObjectsToCaching.cacheKey);
        }
    }
}
