using CleanArchitecture.Ejemplo.BlazorApp;
using CleanArchitecture.Ejemplo.BlazorApp.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMemoryCache();

builder.Services.AddHttpClientFactories();

await builder.Build().RunAsync();
