using System.Net.Http.Json;

using BlazorAuthenticationJWT.Peticiones.Response;

using Microsoft.AspNetCore.Components;

namespace BlazorAuthenticationJWT.Pages;

public partial class Index
{
    [Inject]
    private IHttpClientFactory? HttpClientFactory { get; set; }

    private IEnumerable<UserResponse>? users;

    protected override async Task OnInitializedAsync()
    {
        var httpClient = HttpClientFactory?.CreateClient("API-CleanArchitecture");
        if (httpClient is not null)
        {
            users = await httpClient.GetFromJsonAsync<IEnumerable<UserResponse>>("user/GetUsers");
        }
    }
}
