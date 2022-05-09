using System;
using MySql.Data.MySqlClient;

namespace MySqlDatabase.MySQL
{
    internal class SelectMysql
    {
        public SelectMysql(string connectionString)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    var select = "SELECT * FROM Empleado";

                    // Ejecutamos una select y leemos los datos
                    using var comandoSelect = new MySqlCommand(select, connection);
                    using var leerSelect = comandoSelect.ExecuteReader();

                    // Leemos el array, cada posicion es el numero de columna por indice
                    while (leerSelect.Read())
                    {
                        // El 0 es la primera columna, el 1 la segunda, el 2 la tercera, etc.
                        Console.WriteLine(
                            leerSelect["ID"]
                            + " -- " +
                            leerSelect["Nombre"] 
                            + " -- " +
                            leerSelect["Apellidos"] 
                            + " -- " + 
                            leerSelect["Salario"]);
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
