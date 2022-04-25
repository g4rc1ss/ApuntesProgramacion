namespace CleanArchitecture.Ejemplo.BlazorApp.Extensions
{
    public static class HttpFactories
    {
        public static IServiceCollection AddHttpClientFactories(this IServiceCollection services)
        {
            services.AddHttpClient("API-CleanArchitecture", httpClient =>
            {
                httpClient.BaseAddress = new Uri("https://localhost:7284/api/");
            });

            return services;
        }
    }
}
