using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace SqliteDatabase.SQLite
{
    internal class SelectSqlite
    {
        public SelectSqlite(string connectionString)
        {
            using (var connect = new SqliteConnection(connectionString))
            {
                connect.Open();
                using (var command = new SqliteCommand("SELECT * from EMPRESA", connect))
                {
                    var tabla = new DataTable();
                    tabla.Load(command.ExecuteReader());
                    foreach (DataRow row in tabla.Rows)
                    {
                        Console.WriteLine(
                            $"{row.Field<long>("ID")} \n" +
                            $"{row.Field<string>("NOMBRE")} \n" +
                            $"{row.Field<long>("EDAD")} \n" +
                            $"{row.Field<string>("DIRECCION")} \n" +
                            $"{row.Field<double>("SALARIO")} \n"
                        );
                    }
                }
            }
        }
    }
}
