
using BenchmarkDotNet.Running;
using Benchmarking;

var summary = BenchmarkRunner.Run<ThreadsVsAsync>();

Console.WriteLine(summary.ToString());


/**
 * 
 * |                          Method |     Mean |    Error |   StdDev |
 * |-------------------------------- |---------:|---------:|---------:|
 * |        ExecuteWithParallelAsync |  2.008 s | 0.0051 s | 0.0047 s |
 * |            ExecuteWithTaskAsync |  2.009 s | 0.0048 s | 0.0045 s |
 * | ExecuteAsyncWithAwaitSecuential | 10.041 s | 0.0114 s | 0.0107 s |
 * |        ExecuteWithAsyncBlocking | 10.040 s | 0.0167 s | 0.0157 s |
 * 
 */
