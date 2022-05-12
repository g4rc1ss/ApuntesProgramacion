using AutoMapperBenchmark.Benchmarks;
using BenchmarkDotNet.Running;


BenchmarkRunner.Run<Mappers>();



//|                                       Method |              Mean |             Error |            StdDev |            Median |      Gen 0 |      Gen 1 |     Gen 2 |     Allocated |
//|--------------------------------------------- |------------------:|------------------:|------------------:|------------------:|-----------:|-----------:|----------:|--------------:|
//| AutoMapperEnviandoObjectoOrigenObjetoDestino |         135.72 ns |          3.433 ns |          9.738 ns |         132.68 ns |     0.0324 |          - |         - |         136 B |
//|                                   AutoMapper |         134.61 ns |          1.677 ns |          1.569 ns |         135.01 ns |     0.0324 |          - |         - |         136 B |
//|                             ImplicitOperator |          30.45 ns |          0.635 ns |          1.325 ns |          30.18 ns |     0.0325 |          - |         - |         136 B |
//|                             AutomapperListas | 393,111,497.28 ns | 10,051,835.173 ns | 28,351,379.448 ns | 387,177,350.00 ns | 22500.0000 |  8000.0000 | 1000.0000 | 152,778,812 B |
//|                       ImplicitOperatorListas | 331,517,805.00 ns |  4,142,036.473 ns |  4,769,975.362 ns | 331,369,525.00 ns | 22500.0000 |  8000.0000 | 1000.0000 | 144,001,264 B |
//|               RelacionLinqAutomapperEnSelect | 173,755,438.89 ns |  3,400,276.806 ns |  4,421,320.306 ns | 175,081,983.33 ns | 17000.0000 |          - |         - |  88,778,304 B |
//|              RelacionLinqMapeoManualEnSelect | 616,048,356.25 ns | 12,265,753.991 ns | 19,096,301.244 ns | 611,610,250.00 ns | 35000.0000 | 12000.0000 | 1000.0000 | 232,779,512 B |


// * Legends *
  //Mean      : Arithmetic mean of all measurements
  //Error     : Half of 99.9% confidence interval
  //StdDev    : Standard deviation of all measurements
  //Gen 0     : GC Generation 0 collects per 1000 operations
  //Gen 1     : GC Generation 1 collects per 1000 operations
  //Gen 2     : GC Generation 2 collects per 1000 operations
  //Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  //1 ns      : 1 Nanosecond (0.000000001 sec)
