namespace HttpClientVsHttpClientFactory;

public class PruebaHttpClientFactory(IHttpClientFactory httpClientFactory)
{
    public async Task ExecutePrueba(string endpoint)
    {
        using var client = httpClientFactory.CreateClient();

        await client.GetAsync(endpoint);
    }
}
