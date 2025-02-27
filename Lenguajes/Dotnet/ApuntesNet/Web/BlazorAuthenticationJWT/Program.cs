﻿using BlazorAuthenticationJWT;
using BlazorAuthenticationJWT.Extensions;
using BlazorAuthenticationJWT.Pages.Account;

using Blazored.LocalStorage;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder? builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClientFactories();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddMemoryCache();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProvider>();

await builder.Build().RunAsync();
