using System.Diagnostics;
using HttpClientVsHttpClientFactory;
using Microsoft.Extensions.DependencyInjection;


var services = new ServiceCollection();
services.AddTransient<PruebaHttpClientFactory>();
services.AddTransient<PruebaUsingHttpClient>();
services.AddTransient<PruebaHttpClient>();
services.AddHttpClient();

var serviceProvider = services.BuildServiceProvider();

var endpoint = "https://jsonplaceholder.typicode.com/posts/1";

// Comprobar la IP, puede cambiar
var ipEndpointToCheck = "172.64.100.22.443";


foreach (var item in Enumerable.Range(0, 10))
{
    var httpClientFactory = serviceProvider.GetRequiredService<PruebaHttpClientFactory>();
    await httpClientFactory.ExecutePrueba(endpoint);
}
Console.WriteLine("HttpClientFactory");
Console.WriteLine("------------------------------------------------------------------------------------");
Process.Start("bash", @$"-c ""netstat -an | awk '$5 == \""{ipEndpointToCheck}\""'""");
Console.WriteLine("------------------------------------------------------------------------------------");


foreach (var item in Enumerable.Range(0, 10))
{
    var usingHttpClient = serviceProvider.GetRequiredService<PruebaUsingHttpClient>();
    await usingHttpClient.ExecutePrueba(endpoint);
}
Console.WriteLine("Using HttpClient");
Console.WriteLine("------------------------------------------------------------------------------------");
Process.Start("bash", @$"-c ""netstat -an | awk '$5 == \""{ipEndpointToCheck}\""'""");
Console.WriteLine("------------------------------------------------------------------------------------");


foreach (var item in Enumerable.Range(0, 10))
{
    var pruebaHttpClient = serviceProvider.GetRequiredService<PruebaHttpClient>();
    await pruebaHttpClient.ExecutePrueba(endpoint);
}
Console.WriteLine("HttpClient In Ctor");
Console.WriteLine("------------------------------------------------------------------------------------");
Process.Start("bash", @$"-c ""netstat -an | awk '$5 == \""{ipEndpointToCheck}\""'""");
Console.WriteLine("------------------------------------------------------------------------------------");


Console.WriteLine("Finish");
