using BenchmarkDotNet.Running;

using UnmanagedMemoryVsNormalBenchmark;


var runs = new Type[] { typeof(MarshallApi), typeof(Pointers), typeof(StackallocMemory) };
BenchmarkRunner.Run(runs);