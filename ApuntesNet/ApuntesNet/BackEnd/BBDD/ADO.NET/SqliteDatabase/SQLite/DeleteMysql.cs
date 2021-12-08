using System;
using Microsoft.Data.Sqlite;

namespace SqliteDatabase.SQLite {
    internal class DeleteMysql {
        public DeleteMysql(string connectionString) {
            using (var connection = new SqliteConnection(connectionString)) {
                connection.Open();
                var delete = "DELETE FROM EMPRESA WHERE SALARIO = 4500.00";
                using (var comandoDelete = new SqliteCommand(delete, connection)) {
                    var numeroCambios = comandoDelete.ExecuteNonQuery();
                    Console.WriteLine($"Rows cambiadas: {numeroCambios}");
                }
            }
        }
    }
}
