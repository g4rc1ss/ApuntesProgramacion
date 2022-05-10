using System.Net.Http.Json;
using BlazorJWT.SharedApiDTO.Response;
using Microsoft.AspNetCore.Components;

namespace BlazorJWT.Pages
{
    public partial class Index
    {
        [Inject]
        private IHttpClientFactory? HttpClientFactory { get; set; }

        private IEnumerable<UserResponse>? _users;

        protected override async Task OnInitializedAsync()
        {
            var httpClient = HttpClientFactory?.CreateClient("API-CleanArchitecture");
            if (httpClient is not null)
            {
                _users = await httpClient.GetFromJsonAsync<IEnumerable<UserResponse>>("user/GetUsers");
            }
        }
    }
}
