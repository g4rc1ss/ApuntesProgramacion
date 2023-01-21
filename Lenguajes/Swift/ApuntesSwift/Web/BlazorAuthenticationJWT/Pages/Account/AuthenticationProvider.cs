using System.Security.Claims;
using BlazorAuthenticationJWT.Configuration;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Caching.Memory;

namespace BlazorAuthenticationJWT.Pages.Account
{
    public class AuthenticationProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IMemoryCache _memoryCache;

        public AuthenticationProvider(ILocalStorageService localStorage, IMemoryCache memoryCache)
        {
            _localStorage = localStorage;
            _memoryCache = memoryCache;
        }

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
            await _localStorage.RemoveItemAsync(KeysOfLocalStorage.TokenLocalStorageKey);
            _memoryCache.Remove(KeysOfMemoryCache.TokenMemoryCacheKey);
            var claim = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claim)));
        }


        private async Task<ClaimsPrincipal> GetClaimsAsync()
        {
            ClaimsIdentity? identity;
            var token = await _localStorage.GetItemAsStringAsync(KeysOfLocalStorage.TokenLocalStorageKey);
            if (token is not null)
            {
                _memoryCache.Set(KeysOfMemoryCache.TokenMemoryCacheKey, token);
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Authentication, token)
                }, "apiauth_type");
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

            await _localStorage.SetItemAsStringAsync(KeysOfLocalStorage.TokenLocalStorageKey, token);
            _memoryCache.Set(KeysOfMemoryCache.TokenMemoryCacheKey, token);
            if (token is not null)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Authentication, token)
                }, "apiauth_type");
            }
            else
            {
                identity = new ClaimsIdentity();
            }
            return new ClaimsPrincipal(identity);
        }
    }
}
