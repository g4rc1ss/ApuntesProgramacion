namespace HttpClientVsHttpClientFactory;

public class PruebaHttpClient
{
    private readonly HttpClient _client;

    public PruebaHttpClient(HttpClient client)
    {
        _client = client;
    }

    public async Task ExecutePrueba(string endpoint)
    {
        await _client.GetAsync(endpoint);
    }
}
