using System;
using HttpRequests;
using HttpRequests.Internal;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = HelperDI.GetServideProvider();

var usarHttpClient = serviceProvider.GetRequiredService<UsarHttpClient>();
await usarHttpClient.ExecuteHttpClientAsync();


Console.WriteLine("Pulsa un boton para terminar...");
Console.ReadKey();
