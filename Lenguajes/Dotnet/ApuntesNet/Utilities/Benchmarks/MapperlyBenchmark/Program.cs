using BenchmarkDotNet.Running;
using MapperlyBenchmark.Benchmarks;
using MapperlyBenchmark.ConfigurationBenchmark;


BenchmarkRunner.Run<Mappers>(new Config());

