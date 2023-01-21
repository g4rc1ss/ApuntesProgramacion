using AutoMapperBenchmark.Benchmarks;
using AutoMapperBenchmark.ConfigurationBenchmark;
using BenchmarkDotNet.Running;


BenchmarkRunner.Run<Mappers>(new Config());



//|                                       Method |          Mean |       StdDev |         Error |    Gen 0 |    Gen 1 |   Allocated |
//|--------------------------------------------- |--------------:|-------------:|--------------:|---------:|---------:|------------:|
//|                             ImplicitOperator |      29.81 ns |     0.351 ns |      0.531 ns |   0.0325 |        - |       136 B |
//| AutoMapperEnviandoObjectoOrigenObjetoDestino |     129.92 ns |     4.465 ns |      6.750 ns |   0.0325 |        - |       136 B |
//|                                   AutoMapper |     140.29 ns |     1.402 ns |      2.119 ns |   0.0325 |        - |       136 B |
//|                       ImplicitOperatorListas | 226,898.49 ns | 3,014.721 ns |  4,557.828 ns | 125.0000 |  62.2500 |   720,128 B |
//|                             AutomapperListas | 301,218.36 ns | 5,039.981 ns |  8,469.361 ns | 156.5000 |  65.5000 |   811,360 B |
//|              RelacionLinqMapeoManualEnSelect | 608,230.78 ns | 8,245.645 ns | 12,466.239 ns | 210.0000 | 104.0000 | 1,211,689 B |
//|               RelacionLinqAutomapperEnSelect | 815,840.97 ns | 7,818.287 ns | 11,820.134 ns | 117.0000 |  23.0000 |   491,753 B |
