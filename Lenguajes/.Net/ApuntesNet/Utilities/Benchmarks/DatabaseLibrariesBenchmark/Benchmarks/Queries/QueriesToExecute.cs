using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLibrariesBenchmark.Benchmarks.Queries
{
    internal class QueriesToExecute
    {

        public static string SelectOne = @"
SELECT * 
FROM BenchmarkingDatabases.WeatherForecast
LIMIT 0, 1";

        public static string SelectAll = @"
SELECT * 
FROM BenchmarkingDatabases.WeatherForecast";
    }
}
