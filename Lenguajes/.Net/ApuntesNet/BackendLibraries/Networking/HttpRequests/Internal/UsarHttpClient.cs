using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HttpRequests.Internal
{
    internal class UsarHttpClient
    {
        private readonly HttpClient _httpClient;

        public UsarHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("clientePrueba");
        }

        public Task<object> ExecuteHttpClientAsync()
        {
            return _httpClient.GetFromJsonAsync<object>("pokemon/lucario");
        }
    }
}
