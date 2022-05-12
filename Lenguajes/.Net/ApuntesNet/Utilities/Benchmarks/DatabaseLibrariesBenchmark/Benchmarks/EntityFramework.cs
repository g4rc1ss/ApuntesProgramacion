using BenchmarkDotNet.Attributes;

namespace DatabaseLibrariesBenchmark.Benchmarks
{
    public partial class DatabaseFrameworksPerformance
    {
        [Benchmark]
        public void EntityFrameworkCoreSelectSingleQuery()
        {
            var result = _benchmarkContext.WeatherForecast.Take(1)  .Single();
        }

        [Benchmark]
        public void EntityFrameworkCoreSelectAllResults()
        {
            var result = _benchmarkContext.WeatherForecast.ToList();
        }
    }
}
