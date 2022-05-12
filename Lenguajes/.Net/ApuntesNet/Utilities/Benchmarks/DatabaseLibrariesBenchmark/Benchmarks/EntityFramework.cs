using BenchmarkDotNet.Attributes;

namespace DatabaseLibrariesBenchmark.Benchmarks
{
    public partial class DatabaseFrameworksPerformance
    {
        [Benchmark]
        public void EntityFrameworkCoreSelectSingleQuery()
        {
            _benchmarkContext.WeatherForecasts.Single();
        }

        [Benchmark]
        public void EntityFrameworkCoreSelectAllResults()
        {
            _benchmarkContext.WeatherForecasts.ToList();
        }
    }
}
