using DeferredExecutionYield.ExplicitEnumerator.AsyncEnumerableClass;
using DeferredExecutionYield.ExplicitEnumerator.EnumerableClass;
using DeferredExecutionYield.YieldEnumerator;





var yieldEnumerable = new YieldExecution().GetEnumerableWithYield();
var asyncYield = new YieldExecution().GetAsyncEnumerableWithYieldAsync();

foreach (var item in yieldEnumerable) ;
await foreach (var item in asyncYield) ;


var enumerableExplicito = new ExplicitEnumerable();
var enumerableAsincronoExplicito = new ExplicitAsyncEnumerable();


foreach (var item in enumerableExplicito) ;
await foreach (var item in enumerableAsincronoExplicito) ;



Console.WriteLine("Teclee para cerrar la ventana...");
Console.Read();
