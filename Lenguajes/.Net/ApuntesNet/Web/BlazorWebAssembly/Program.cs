using Blazored.LocalStorage;
using BlazorWebAssembly;
using BlazorWebAssembly.Extensions;
using BlazorWebAssembly.Pages.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClientFactories();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddMemoryCache();

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationProvider>();

await builder.Build().RunAsync();
