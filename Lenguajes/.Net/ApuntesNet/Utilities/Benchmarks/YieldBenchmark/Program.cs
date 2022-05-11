using BenchmarkDotNet.Running;
using Benchmarking.Benchmarks;


// INIT DATA \\
var collection = Enumerable.Range(0, 1_000_000).Select(x => $"registro {x}").ToArray();
File.WriteAllLines("archivoLectura.txt", collection);


BenchmarkRunner.Run<YieldVsList>();
