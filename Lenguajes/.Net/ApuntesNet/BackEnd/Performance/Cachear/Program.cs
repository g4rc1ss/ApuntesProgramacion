using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

IServiceCollection services = new ServiceCollection();
services.AddMemoryCache();
var app = services.BuildServiceProvider();

var _memoryCache = app.GetRequiredService<IMemoryCache>();

var lista = new List<string>()
{
    "",
    "",
    "",
    "",
};

var timeStart = DateTime.Now.TimeOfDay;
Console.WriteLine($"Obtenemos la lista {timeStart}");
_memoryCache.Set("hola", lista, TimeSpan.FromMinutes(1));

await Task.Delay(TimeSpan.FromSeconds(25));

Console.WriteLine($"Obtenemos la lista {DateTime.Now.TimeOfDay}");
_memoryCache.TryGetValue("hola", out lista);

await Task.Delay(TimeSpan.FromSeconds(50));


Console.WriteLine($"El tiempo transcurrido total es de {DateTime.Now.TimeOfDay - timeStart}");
if (_memoryCache.TryGetValue("hola", out lista))
{
    Console.WriteLine("Hemos obtenido la lista");
}
else
{
    Console.WriteLine("No hemos podido obtener la lista de cache");
}

Console.WriteLine("\n Pulsa una tecla para finalizar");
Console.ReadKey();
