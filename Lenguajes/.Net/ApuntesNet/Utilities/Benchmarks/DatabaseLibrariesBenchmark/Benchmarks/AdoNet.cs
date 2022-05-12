using BenchmarkDotNet.Attributes;
using DatabaseLibrariesBenchmark.Benchmarks.Queries;
using DatabaseLibrariesBenchmark.Entities;
using MySql.Data.MySqlClient;

namespace DatabaseLibrariesBenchmark.Benchmarks
{
    public partial class DatabaseFrameworksPerformance
    {

        [Benchmark]
        public void ADONETSingleQuery()
        {
            _dbConnection.Open();

            using var comando = _dbConnection.CreateCommand();
            comando.CommandText = QueriesToExecute.SelectOne;

            using var leerSelect = comando.ExecuteReader();

            // Leemos el array, cada posicion es el numero de columna por indice
            while (leerSelect.Read())
            {
                new WeatherForecast
                {
                    Id = int.TryParse(leerSelect["Id"].ToString(), out var id) ? id : default,
                    Date = DateTime.TryParse(leerSelect["Date"].ToString(), out var date) ? date : default,
                    Summary = leerSelect["Summary"].ToString(),
                    TemperatureC = int.TryParse(leerSelect["TemperatureC"].ToString(), out var temC) ? temC : default,
                    TemperatureF = int.TryParse(leerSelect["TemperatureF"].ToString(), out var temF) ? temF : default
                };
            }

            _dbConnection.Close();
        }

        [Benchmark]
        public void ADONETSelectAllResults()
        {
            _dbConnection.Open();

            using var comando = _dbConnection.CreateCommand();
            comando.CommandText = QueriesToExecute.SelectAll;

            using var leerSelect = comando.ExecuteReader();

            var buffer = new List<WeatherForecast>();
            while (leerSelect.Read())
            {
                buffer.Add(new WeatherForecast
                {
                    Id = int.TryParse(leerSelect["Id"].ToString(), out var id) ? id : default,
                    Date = DateTime.TryParse(leerSelect["Date"].ToString(), out var date) ? date : default,
                    Summary = leerSelect["Summary"].ToString(),
                    TemperatureC = int.TryParse(leerSelect["TemperatureC"].ToString(), out var temC) ? temC : default,
                    TemperatureF = int.TryParse(leerSelect["TemperatureF"].ToString(), out var temF) ? temF : default
                });
            }

            _dbConnection.Close();
        }
    }
}
