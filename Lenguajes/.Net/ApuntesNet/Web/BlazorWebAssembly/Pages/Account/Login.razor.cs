using System.Net.Http.Json;
using BlazorWebAssembly.SharedApiDTO.Request;
using Microsoft.AspNetCore.Components;

namespace BlazorWebAssembly.Pages.Account
{
    public partial class Login
    {
        [Inject]
        private IHttpClientFactory? HttpClientFactory { get; set; }

        private LoginRequest LoginRequest { get; set; }

        private async void EnviarLogin()
        {
            var httpClient = HttpClientFactory.CreateClient("API-CleanArchitecture");
            var jwt = await httpClient.PostAsJsonAsync("Login", LoginRequest);
        }
    }
}
