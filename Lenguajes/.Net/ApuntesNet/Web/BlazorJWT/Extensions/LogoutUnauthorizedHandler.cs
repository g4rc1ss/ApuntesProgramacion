using System.Net;
using BlazorJWT.Pages.Account;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorJWT.Extensions
{
    public class LogoutUnauthorizedHandler : DelegatingHandler
    {
        private readonly AuthenticationProvider _authenticationProvider;
        private NavigationManager _navigation;

        public LogoutUnauthorizedHandler(AuthenticationStateProvider authenticationStateProvider, NavigationManager navigation)
        {
            _authenticationProvider = (AuthenticationProvider)authenticationStateProvider;
            _navigation = navigation;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await _authenticationProvider.SetLogoutAsync();
                _navigation.NavigateTo("/", true);
                return new HttpResponseMessage();
            }

            return response;
        }
    }
}
