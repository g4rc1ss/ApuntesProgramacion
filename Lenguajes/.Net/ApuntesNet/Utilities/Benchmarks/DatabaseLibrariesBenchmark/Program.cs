using BenchmarkDotNet.Running;
using DatabaseLibrariesBenchmark.Benchmarks;


//var performance = new DatabaseFrameworksPerformance();

//performance.DapperSelectSingleQuery();
//performance.DapperSelectAllResults();

//performance.EntityFrameworkCoreSelectSingleQuery();
//performance.EntityFrameworkCoreSelectAllResults();

//performance.ADONETSingleQuery();
//performance.ADONETSelectAllResults();

BenchmarkRunner.Run<DatabaseFrameworksPerformance>();



//|                               Method |      Mean |     Error |    StdDev |    Median |     Gen 0 |     Gen 1 |   Gen 2 | Allocated |
//|------------------------------------- |----------:|----------:|----------:|----------:|----------:|----------:|--------:|----------:|
//|                    ADONETSingleQuery |  2.552 ms | 0.0488 ms | 0.1029 ms |  2.595 ms |         - |         - |       - |      9 KB |
//|               ADONETSelectAllResults | 42.060 ms | 0.9552 ms | 2.7408 ms | 41.993 ms | 2000.0000 | 1000.0000 |       - | 10,889 KB |
//|              DapperSelectSingleQuery |  2.803 ms | 0.0535 ms | 0.0677 ms |  2.790 ms |         - |         - |       - |      9 KB |
//|               DapperSelectAllResults | 26.204 ms | 0.8420 ms | 2.4560 ms | 25.564 ms | 1000.0000 |         - |       - |  9,297 KB |
//| EntityFrameworkCoreSelectSingleQuery |  1.558 ms | 0.0288 ms | 0.0691 ms |  1.549 ms |    1.9531 |         - |       - |     15 KB |
//|  EntityFrameworkCoreSelectAllResults | 19.491 ms | 1.9287 ms | 5.6262 ms | 18.119 ms |  640.6250 |   46.8750 | 15.6250 |  2,731 KB |
