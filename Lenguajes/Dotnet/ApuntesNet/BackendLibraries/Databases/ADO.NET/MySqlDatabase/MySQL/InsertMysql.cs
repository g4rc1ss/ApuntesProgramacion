using MySql.Data.MySqlClient;

namespace MySqlDatabase.MySQL;

internal class InsertMysql
{
    public InsertMysql(string connectionString)
    {
        using var connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            var insert = "INSERT INTO Empleado (Nombre, Apellidos, Salario) VALUES ('nombre','apellido', 20000.00)";

            using var comandoInsert = new MySqlCommand(insert, connection);
            var numeroCambios = comandoInsert.ExecuteNonQuery();
            Console.WriteLine($"Rows cambiadas: {numeroCambios}");
        }
        finally
        {
            connection.Close();

        }
    }
}
