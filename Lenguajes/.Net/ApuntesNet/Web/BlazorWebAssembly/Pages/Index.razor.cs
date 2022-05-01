using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Memory;

namespace CleanArchitecture.Ejemplo.BlazorApp.Pages
{
    public partial class Index
    {
        [Inject]
        private IHttpClientFactory? HttpClientFactory { get; set; }
        [Inject]
        private IMemoryCache MemoryCache { get; set; }

    }
}
