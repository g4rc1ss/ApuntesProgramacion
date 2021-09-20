using System;
using MySql.Data.MySqlClient;

namespace MySqlDatabase.MySQL {
    public class UsarBBDD_MySQL {
        public static void BaseMySQL() {
            var connStr = $"server=localhost;user=root;database=apuntesnet;port=3306;password=123456";

            using (var conn = new MySqlConnection(connStr)) {
                try {
                    // Conectamos con la base de datos
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();

                    // Ejecutamos un insert datos, con esto se ejecutan tambn las updates, deletes, etc
                    var insert = "INSERT INTO Empleado (Nombre, Apellidos, Salario) VALUES ('nombre','apellido', 20000.00)";

                    var delete = "DELETE FROM `apuntesnet`.`Empleado` WHERE (`ID` = '2')";

                    var update = "UPDATE Empleado set Salario = 4500.00 where ID = 1";

                    using (var comandoInsert = new MySqlCommand(insert, conn)) {
                        var numeroCambios = comandoInsert.ExecuteNonQuery();
                        Console.WriteLine($"Rows cambiadas: {numeroCambios}");
                    }

                    using (var comandoUpdate = new MySqlCommand(update, conn)) {
                        var numeroCambios = comandoUpdate.ExecuteNonQuery();
                        Console.WriteLine($"Rows cambiadas: {numeroCambios}");
                    }

                    using (var comandoDelete = new MySqlCommand(delete, conn)) {
                        var numeroCambios = comandoDelete.ExecuteNonQuery();
                        Console.WriteLine($"Rows cambiadas: {numeroCambios}");
                    }

                    // Ejecutamos una select y leemos los datos
                    var sql = "SELECT * FROM Empleado";
                    using (var comandoSelect = new MySqlCommand(sql, conn)) {
                        using (var leerSelect = comandoSelect.ExecuteReader()) {
                            // Leemos el array, cada posicion es el numero de columna por indice
                            while (leerSelect.Read()) {
                                // El 0 es la primera columna, el 1 la segunda, el 2 la tercera, etc.
                                Console.WriteLine(leerSelect[0] + " -- " + leerSelect[1] + "--" + leerSelect[2] + "--" + leerSelect[3]);
                            }
                            leerSelect.Close();
                        }
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                }
                conn.Close();
            }
            Console.WriteLine("Done.");
        }
    }
}
