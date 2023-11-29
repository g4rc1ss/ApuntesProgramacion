namespace HttpClientVsHttpClientFactory;

public class PruebaUsingHttpClient
{
    public async Task ExecutePrueba(string endpoint)
    {
        using var client = new HttpClient();

        await client.GetAsync(endpoint);
    }
}
