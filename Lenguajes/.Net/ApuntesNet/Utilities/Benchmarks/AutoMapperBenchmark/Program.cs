using AutoMapperBenchmark.Benchmarks;
using BenchmarkDotNet.Running;


BenchmarkRunner.Run<Mappers>();



//|                 Method |              Mean |            Error |            StdDev |      Gen 0 |     Gen 1 |     Gen 2 |     Allocated |
//|----------------------- |------------------:|-----------------:|------------------:|-----------:|----------:|----------:|--------------:|
//|             AutoMapper |         141.80 ns |         2.749 ns |          4.439 ns |     0.0324 |         - |         - |         136 B |
//|       ImplicitOperator |          33.17 ns |         0.689 ns |          1.527 ns |     0.0325 |         - |         - |         136 B |
//|       AutomapperListas | 362,178,192.11 ns | 7,091,786.376 ns | 12,232,983.058 ns | 22500.0000 | 8000.0000 | 1000.0000 | 152,778,280 B |
//| ImplicitOperatorListas | 362,039,063.57 ns | 6,740,789.275 ns | 16,408,012.724 ns | 22500.0000 | 8000.0000 | 1000.0000 | 144,000,776 B |


// * Legends *
  //Mean      : Arithmetic mean of all measurements
  //Error     : Half of 99.9% confidence interval
  //StdDev    : Standard deviation of all measurements
  //Gen 0     : GC Generation 0 collects per 1000 operations
  //Gen 1     : GC Generation 1 collects per 1000 operations
  //Gen 2     : GC Generation 2 collects per 1000 operations
  //Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  //1 ns      : 1 Nanosecond (0.000000001 sec)
