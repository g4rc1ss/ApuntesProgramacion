using System.Security.Claims;

using BlazorAuthenticationJWT.Configuration;

using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Caching.Memory;

namespace BlazorAuthenticationJWT.Pages.Account;

public class AuthenticationProvider(ILocalStorageService localStorage, IMemoryCache memoryCache) : AuthenticationStateProvider
{

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var claim = await GetClaimsAsync();
        return new AuthenticationState(new ClaimsPrincipal(claim));
    }

    public async Task SetAuthenticationAsync(string token)
    {
        var claim = await SetClaimsAsync(token);

        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claim)));
    }

    public async Task SetLogoutAsync()
    {
        await localStorage.RemoveItemAsync(KeysOfLocalStorage.TOKENLOCALSTORAGEKEY);
        memoryCache.Remove(KeysOfMemoryCache.TOKENMEMORYCACHEKEY);
        var claim = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claim)));
    }


    private async Task<ClaimsPrincipal> GetClaimsAsync()
    {
        ClaimsIdentity? identity;
        var token = await localStorage.GetItemAsStringAsync(KeysOfLocalStorage.TOKENLOCALSTORAGEKEY);
        if (token is not null)
        {
            memoryCache.Set(KeysOfMemoryCache.TOKENMEMORYCACHEKEY, token);
            identity = new ClaimsIdentity([
                new Claim(ClaimTypes.Authentication, token)
            ], "apiauth_type");
        }
        else
        {
            identity = new ClaimsIdentity();
        }
        return new ClaimsPrincipal(identity);
    }

    private async Task<ClaimsPrincipal> SetClaimsAsync(string token)
    {
        ClaimsIdentity? identity;
        token = $"Bearer {token}";

        await localStorage.SetItemAsStringAsync(KeysOfLocalStorage.TOKENLOCALSTORAGEKEY, token);
        memoryCache.Set(KeysOfMemoryCache.TOKENMEMORYCACHEKEY, token);
        identity = token is not null
            ? new ClaimsIdentity([
                new Claim(ClaimTypes.Authentication, token)
            ], "apiauth_type")
            : new ClaimsIdentity();
        return new ClaimsPrincipal(identity);
    }
}
