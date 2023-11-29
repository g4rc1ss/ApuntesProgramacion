using System.Diagnostics;

namespace HttpClientVsHttpClientFactory;

public class PruebaHttpClientFactory
{
    private readonly IHttpClientFactory _httpClientFactory;

    public PruebaHttpClientFactory(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task ExecutePrueba(string endpoint)
    {
        var client = _httpClientFactory.CreateClient();

        await client.GetAsync(endpoint);
    }
}
