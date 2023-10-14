using BenchmarkDotNet.Running;
using MapperlyBenchmark.Benchmarks;
using MapperlyBenchmark.ConfigurationBenchmark;

BenchmarkRunner.Run<Mappers>(new Config());


// |                          Method |          Mean |       StdDev |        Error |    Gen 0 |   Gen 1 |   Allocated |
// |-------------------------------- |--------------:|-------------:|-------------:|---------:|--------:|------------:|
// |                ImplicitOperator |      33.05 ns |     0.038 ns |     0.064 ns |   0.0217 |       - |       136 B |
// |                        Mapperly |      33.50 ns |     0.037 ns |     0.071 ns |   0.0217 |       - |       136 B |
// |                  MapperlyListas | 229,301.74 ns | 1,841.667 ns | 2,784.338 ns | 114.7500 | 49.0000 |   720,192 B |
// |          ImplicitOperatorListas | 230,186.30 ns | 2,572.463 ns | 3,889.198 ns | 114.7500 | 49.0000 |   720,128 B |
// |    RelacionLinqMapperlyEnSelect | 429,154.62 ns | 2,540.978 ns | 4,269.949 ns | 192.5000 | 70.0000 | 1,211,752 B |
// | RelacionLinqMapeoManualEnSelect | 545,477.71 ns | 4,871.305 ns | 7,364.718 ns | 192.0000 | 69.0000 | 1,211,689 B |
