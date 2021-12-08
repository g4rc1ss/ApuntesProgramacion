using System.Text;
using Microsoft.Data.Sqlite;

namespace SqliteDatabase.SQLite {
    internal class CreateDatabaseAndTables {
        public CreateDatabaseAndTables(string connectionString) {
            using (var connection = new SqliteConnection(connectionString)) {
                connection.Open();
                var sqlCreateTable = new StringBuilder("CREATE TABLE EMPRESA(")
                    .AppendLine("ID          INT       PRIMARY KEY      NOT NULL,")
                    .AppendLine("NOMBRE      TEXT                       NOT NULL,")
                    .AppendLine("EDAD        INT                        NOT NULL,")
                    .AppendLine("DIRECCION   TEXT                       NOT NULL,")
                    .AppendLine("SALARIO     REAL)").ToString();

                using (var executeCreateDatabase = new SqliteCommand(sqlCreateTable, connection)) {
                    executeCreateDatabase.ExecuteNonQuery();
                }
            }
        }
    }
}
