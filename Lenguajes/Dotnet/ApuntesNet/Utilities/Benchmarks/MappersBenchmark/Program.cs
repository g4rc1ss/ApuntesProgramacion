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


// BenchmarkRunner.Run<Mappers>(new Config());
new Mappers().MapperObjectAutoMapper();
new Mappers().MapperObjectManual();
new Mappers().MapperObjectMapperly();

new Mappers().MapperListAutoMapper();
new Mappers().MapperListManual();
new Mappers().MapperListMapperly();

public class Config : ManualConfig
{
    public const int Iterations = 500;
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
               .WithUnrollFactor(Iterations)
               .WithIterationCount(10)
        );
        Orderer = new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest);
        Options |= ConfigOptions.JoinSummary;
    }
}
