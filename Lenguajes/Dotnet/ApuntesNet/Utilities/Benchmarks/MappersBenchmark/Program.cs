using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

using MappersBenchmark;


BenchmarkRunner.Run<Mappers>(new Config());


// | Method                 | Mean          | StdDev     | Error        | Gen0       | Gen1      | Gen2      | Allocated   |
// |----------------------- |--------------:|-----------:|-------------:|-----------:|----------:|----------:|------------:|
// | MapperObjectMapperly   |      16.31 us |   0.011 us |     0.021 us |    14.0625 |    2.8125 |         - |    86.26 KB |
// | MapperObjectManual     |      16.46 us |   0.029 us |     0.049 us |    14.0625 |    2.8125 |         - |     86.2 KB |
// | MapperObjectAutoMapper |      26.44 us |   0.063 us |     0.095 us |    15.4063 |    3.1875 |         - |    94.51 KB |
// | MapperListMapperly     |  91,671.95 us | 373.348 us |   627.387 us | 15242.0000 | 5878.0000 | 1712.0000 | 86267.19 KB |
// | MapperListManual       |  92,085.17 us | 211.269 us |   319.408 us | 15222.0000 | 5854.0000 | 1700.0000 | 86204.72 KB |
// | MapperListAutoMapper   | 110,122.26 us | 885.292 us | 1,338.435 us | 16792.0000 | 6808.0000 | 2006.0000 |  94526.2 KB |

// // * Legends *
//   Mean      : Arithmetic mean of all measurements
//   StdDev    : Standard deviation of all measurements
//   Error     : Half of 99.9% confidence interval
//   Gen0      : GC Generation 0 collects per 1000 operations
//   Gen1      : GC Generation 1 collects per 1000 operations
//   Gen2      : GC Generation 2 collects per 1000 operations
//   Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
//   1 us      : 1 Microsecond (0.000001 sec)




public class Config : ManualConfig
{
    public const int ITERATIONS = 500;
    public Config()
    {
        AddLogger(ConsoleLogger.Default);

        AddExporter(CsvExporter.Default);
        AddExporter(MarkdownExporter.GitHub);
        AddExporter(HtmlExporter.Default);

        var md = MemoryDiagnoser.Default;
        AddDiagnoser(md);
        AddColumn(TargetMethodColumn.Method);
        AddColumn(StatisticColumn.Mean);
        AddColumn(StatisticColumn.StdDev);
        AddColumn(StatisticColumn.Error);
        AddColumn(BaselineRatioColumn.RatioMean);
        AddColumnProvider(DefaultColumnProviders.Metrics);

        AddJob(Job.ShortRun
               .WithLaunchCount(1)
               .WithWarmupCount(2)
               .WithUnrollFactor(ITERATIONS)
               .WithIterationCount(10)
        );
        Orderer = new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest);
        Options |= ConfigOptions.JoinSummary;
    }
}
