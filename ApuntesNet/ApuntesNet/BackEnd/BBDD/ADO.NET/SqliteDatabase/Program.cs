using System.IO;
using SqliteDatabase.SQLite;

namespace SqliteDatabase {
    internal class Program {
        private static readonly string dbname = "Database.db";
        private static readonly string connectionString = $"Data Source={dbname};";

        private static void Main(string[] args) {
            try {
                _ = new CreateDatabaseAndTables(connectionString);
                _ = new InsertSqlite(connectionString);
                _ = new UpdateSqlite(connectionString);
                _ = new DeleteMysql(connectionString);
                _ = new SelectSqlite(connectionString);
            } finally {
                File.Delete(dbname);
            }
        }
    }
}
