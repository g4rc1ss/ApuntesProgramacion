using System.Data;
using BenchmarkDotNet.Attributes;
using Dapper;
using DatabaseLibrariesBenchmark.Benchmarks.Queries;
using DatabaseLibrariesBenchmark.Entities;

namespace DatabaseLibrariesBenchmark.Benchmarks
{
    [MemoryDiagnoser]
    public partial class DatabaseFrameworksPerformance
    {
        private readonly IDbConnection _dbConnection;
        private readonly BenchmarkingDbContext _benchmarkContext;

        public DatabaseFrameworksPerformance()
        {
            _dbConnection = Helper.GetDbConnection;
            _benchmarkContext = Helper.GetDbContext;
        }

        [Benchmark]
        public void DapperSelectSingleQuery()
        {
            _dbConnection.QuerySingle<WeatherForecast>(QueriesToExecute.SelectOne);
        }

        [Benchmark]
        public void DapperSelectAllResults()
        {
            _dbConnection.Query<WeatherForecast>(QueriesToExecute.SelectAll);
        }
    }
}
