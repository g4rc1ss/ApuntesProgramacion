using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;

namespace WebApiExample.Database
{
    public class DapperConfig : IDapperConfig
    {
        private readonly string _connectionString;

        public DapperConfig()
        {
            _connectionString = JObject.Parse(File.ReadAllText("appsettings.Development.json"))["Database"].ToString();
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
