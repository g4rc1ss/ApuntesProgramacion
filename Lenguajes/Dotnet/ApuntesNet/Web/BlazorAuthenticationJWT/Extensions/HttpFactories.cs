using BlazorAuthenticationJWT.Configuration;

using Microsoft.Extensions.Caching.Memory;

namespace BlazorAuthenticationJWT.Extensions;

public static class HttpFactories
{
    public static IServiceCollection AddHttpClientFactories(this IServiceCollection services)
    {
        services.AddScoped<LogoutUnauthorizedHandler>();

        services.AddHttpClient("API-CleanArchitecture", (serviceProvider, httpClient) =>
        {
            IMemoryCache? memoryCache = serviceProvider.GetRequiredService<IMemoryCache>();
            if (memoryCache.TryGetValue<string>(KeysOfMemoryCache.TOKENMEMORYCACHEKEY, out string? token))
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", token);
            }
            httpClient.BaseAddress = new Uri("https://localhost:44326/api/");
        }).AddHttpMessageHandler<LogoutUnauthorizedHandler>();

        return services;
    }
}
