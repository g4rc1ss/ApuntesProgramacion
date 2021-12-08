using Microsoft.Data.Sqlite;

namespace SqliteDatabase.SQLite {
    internal class InsertSqlite {
        public InsertSqlite(string connectionString) {
            var id = 0;
            var nombre = "Pablo";
            var edad = 32;
            var direccion = "Montevideo";
            var salario = 20000.00;

            using (var connect = new SqliteConnection(connectionString)) {
                connect.Open();
                using (var command = new SqliteCommand("INSERT INTO EMPRESA (ID, NOMBRE, EDAD, DIRECCION, SALARIO) " +
                                        $"VALUES ({id}, '{nombre}', {edad}, '{direccion}', {salario})", connect)) {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
