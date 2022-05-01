﻿using System.Net.Http.Headers;
using BlazorWebAssembly.Configuration;
using Microsoft.Extensions.Caching.Memory;

namespace BlazorWebAssembly.Extensions
{
    public static class HttpFactories
    {
        public static IServiceCollection AddHttpClientFactories(this IServiceCollection services)
        {
            services.AddScoped<LogoutUnauthorizedHandler>();

            services.AddHttpClient("API-CleanArchitecture", (serviceProvider, httpClient) =>
            {
                var memoryCache = serviceProvider.GetRequiredService<IMemoryCache>();
                if (memoryCache.TryGetValue<string>(KeysOfMemoryCache.TokenMemoryCacheKey, out var token))
                {
                    httpClient.DefaultRequestHeaders.Add("Authorization", token);
                }
                httpClient.BaseAddress = new Uri("https://localhost:44326/api/");
            }).AddHttpMessageHandler<LogoutUnauthorizedHandler>();

            return services;
        }
    }
}
