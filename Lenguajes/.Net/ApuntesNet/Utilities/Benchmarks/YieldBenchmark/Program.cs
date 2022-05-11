using BenchmarkDotNet.Running;
using YieldBenchmark.Benchmarks;


// INIT DATA \\
//var collection = Enumerable.Range(0, 50_000_000).Select(x => $"registro {x}").ToArray();
//File.WriteAllLines("archivoLectura.txt", collection);


BenchmarkRunner.Run<YieldVsList>();


//|                    Method |    Mean |    Error |   StdDev |     Gen 0 |     Gen 1 |     Gen 2 |    Allocated |
//|-------------------------- |--------:|---------:|---------:|----------:|----------:|----------:|-------------:|
//|  ExpensiveObjectsWithList | 8.017 s | 0.0423 s | 0.0375 s | 7000.0000 | 7000.0000 | 7000.0000 | 8,388,615 KB |
//| ExpensiveObjectsWithYield | 8.177 s | 0.0773 s | 0.0723 s |         - |         - |         - |         1 KB |
