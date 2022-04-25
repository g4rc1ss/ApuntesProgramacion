using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace CleanArchitecture.ApplicationCore.NegocioEjemplo.ExtensionsHelper
{
    internal static class DistributedCacheExtension
    {
        internal static async Task<T> GetObjectCache<T>(this IDistributedCache cache, string key)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            var objetoCache = await cache.GetStringAsync(key);
            if (string.IsNullOrEmpty(objetoCache))
            {
                return default;
            }
            return JsonSerializer.Deserialize<T>(objetoCache);
        }

        internal static async Task<T> SetObjectCache<T>(this IDistributedCache cache, string key, T value)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            var jsonValue = JsonSerializer.Serialize(value);
            await cache.SetStringAsync(key, jsonValue);

            return value;
        }
    }
}
