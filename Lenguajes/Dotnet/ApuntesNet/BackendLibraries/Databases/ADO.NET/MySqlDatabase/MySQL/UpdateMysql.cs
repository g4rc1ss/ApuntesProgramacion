using MySql.Data.MySqlClient;

namespace MySqlDatabase.MySQL;

internal class UpdateMysql
{
    public UpdateMysql(string connectionString)
    {
        using var connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            var update = "UPDATE Empleado set Salario = 4500.00 where ID = 1";

            using var comandoUpdate = new MySqlCommand(update, connection);
            var numeroCambios = comandoUpdate.ExecuteNonQuery();
            Console.WriteLine($"Rows cambiadas: {numeroCambios}");
        }
        finally
        {
            connection.Close();

        }
    }
}
