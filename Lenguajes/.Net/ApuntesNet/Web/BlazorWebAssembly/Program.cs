using BlazorWebAssembly.Extensions;
using CleanArchitecture.Ejemplo.BlazorApp;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMemoryCache();

builder.Services.AddHttpClientFactories();

await builder.Build().RunAsync();
