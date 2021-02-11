using MySql.Data.MySqlClient;
using System;

namespace BasesDeDatos.MySQL {
    public class UsarBBDD_MySQL {
        public void BaseMySQL() {
            Console.WriteLine("Escribe la password");
            var connStr = $"server=localhost;user=asier;database=datosPrueba;port=3306;password={Console.ReadLine()}";

            using (var conn = new MySqlConnection(connStr)) {
                try {
                    // Conectamos con la base de datos
                    Console.WriteLine("Connecting to MySQL...");
                    conn.Open();

                    // Ejecutamos un insert datos, con esto se ejecutan tambn las updates, deletes, etc
                    var insert = "INSERT INTO Empleado (Nombre, Apellidos, Salario) VALUES ('nombre','apellido', 20000.00)";

                    //string delete = "DELETE FROM `datosPrueba`.`Empleado` WHERE (`ID` = '2')";

                    //string update = "UPDATE Empleado set Salario = 4500.00 where ID = 1";

                    // `nombreDatabase`.`nombreTable`
                    /*string createTable = "CREATE TABLE `datosPrueba`.`Empleado` (" +
                                            "`ID`         INT             NOT NULL    AUTO_INCREMENT," +
                                            "`Nombre`     VARCHAR(45)                 NULL," +
                                            "`Apellidos`  VARCHAR(45)                 NULL," +
                                            "`Salario`    DOUBLE                      NULL," +
                                            "PRIMARY KEY(`ID`))";*/

                    using (var comandoInsert = new MySqlCommand(insert, conn)) {
                        var numeroCambios = comandoInsert.ExecuteNonQuery();
                        Console.WriteLine($"Rows cambiadas: {numeroCambios}");
                    }

                    // Ejecutamos una select y leemos los datos
                    var sql = "SELECT * FROM Empleado";
                    using (var comandoSelect = new MySqlCommand(sql, conn)) {
                        using (var leerSelect = comandoSelect.ExecuteReader()) {
                            while (leerSelect.Read()) {
                                // Leemos el array, cada posicion es el numero de columna por indice
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
