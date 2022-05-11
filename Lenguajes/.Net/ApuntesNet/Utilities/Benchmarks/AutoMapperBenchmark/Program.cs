using AutoMapperBenchmark.Benchmarks;
using BenchmarkDotNet.Running;


BenchmarkRunner.Run<Mappers>();



//|           Method |      Mean |    Error |   StdDev |  Gen 0 | Allocated |
//|----------------- |----------:|---------:|---------:|-------:|----------:|
//|       AutoMapper | 135.77 ns | 2.532 ns | 2.369 ns | 0.0324 |     136 B |
//| ImplicitOperator |  29.94 ns | 0.514 ns | 0.481 ns | 0.0325 |     136 B |
//|    ManualMapping |  29.82 ns | 0.282 ns | 0.250 ns | 0.0325 |     136 B |
