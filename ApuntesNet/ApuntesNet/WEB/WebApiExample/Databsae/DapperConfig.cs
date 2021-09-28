using System.Data;
using System.Data.SqlClient;
using System.IO;
using Newtonsoft.Json.Linq;

namespace WebApiExample.Databsae {
    public class DapperConfig : IDapperConfig {
        private readonly string _connectionString;

        public DapperConfig() {
            _connectionString = JObject.Parse(File.ReadAllText("appsettings.Development.json"))["Database"].ToString();
        }

        public IDbConnection GetConnection() {
            return new SqlConnection(_connectionString);
        }
    }
}
