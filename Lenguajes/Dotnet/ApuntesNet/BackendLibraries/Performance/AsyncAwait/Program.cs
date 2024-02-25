using AsyncAwait.Async;



var asincronia = new Asincronia();

Console.WriteLine("Ejemplo de codigo asincrono enlazado a CPU");
var tareaCpu = asincronia.CpuAsync();

Console.WriteLine("Ejemplo de codido asincrono E/S");
var tareaES = asincronia.ESAsync();

Console.WriteLine("Ejemplo de codido asincrono en bucles con IAsyncEnumerable");
var tareaForeachAsync = asincronia.ExecuteIEnumerableAsync();

await Task.WhenAll(tareaCpu, tareaES, tareaForeachAsync);
