
using BenchmarkDotNet.Running;
using Benchmarking;

var summary = BenchmarkRunner.Run<ThreadsVsAsync>();

Console.WriteLine(summary.ToString());


/**
 * |                      Method |     Mean |    Error |   StdDev |
 * |---------------------------- |---------:|---------:|---------:|
 * |   ExecuteWithMultiThreading |  2.008 s | 0.0049 s | 0.0046 s |
 * |            ExecuteWithAsync |  2.008 s | 0.0045 s | 0.0042 s |
 * | ExecuteWithOtherMethodAsync |  2.009 s | 0.0043 s | 0.0040 s |
 * |  ExecuteWithOtherMethodSync | 10.046 s | 0.0122 s | 0.0114 s |
 * 
 */
