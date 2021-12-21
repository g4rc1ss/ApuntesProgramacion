using Microsoft.Data.Sqlite;

namespace SqliteDatabase.SQLite
{
    internal class UpdateSqlite
    {
        public UpdateSqlite(string connectionString)
        {
            using (var connect = new SqliteConnection(connectionString))
            {
                connect.Open();
                using (var command = new SqliteCommand("UPDATE EMPRESA set SALARIO = 4500.00 where ID=1", connect))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
