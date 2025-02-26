using System.Net;

using BlazorAuthenticationJWT.Pages.Account;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorAuthenticationJWT.Extensions;

public class LogoutUnauthorizedHandler(AuthenticationStateProvider authenticationStateProvider, NavigationManager navigation) : DelegatingHandler
{
    private readonly AuthenticationProvider _authenticationProvider = (AuthenticationProvider)authenticationStateProvider;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage? response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            await _authenticationProvider.SetLogoutAsync();
            navigation.NavigateTo("/", true);
            return new HttpResponseMessage();
        }

        return response;
    }
}
