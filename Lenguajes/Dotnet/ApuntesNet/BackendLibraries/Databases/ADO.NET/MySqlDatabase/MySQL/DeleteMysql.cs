using System;
using MySql.Data.MySqlClient;

namespace MySqlDatabase.MySQL
{
    internal class DeleteMysql
    {
        public DeleteMysql(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var delete = "DELETE FROM `AdoNetMySqlDatabase`.`Empleado` WHERE (`ID` = '2')";
                    using (var comandoDelete = new MySqlCommand(delete, connection))
                    {
                        var numeroCambios = comandoDelete.ExecuteNonQuery();
                        Console.WriteLine($"Rows cambiadas: {numeroCambios}");
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
