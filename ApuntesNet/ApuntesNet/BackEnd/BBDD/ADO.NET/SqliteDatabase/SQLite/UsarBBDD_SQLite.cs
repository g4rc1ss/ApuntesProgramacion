using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace SqliteDatabase.SQLite {
    public class UsarBBDD_SQLite {
        private SQLiteConnection Conexion => new SQLiteConnection(string.Format($"Data Source={dbName};Version=3;")).OpenAndReturn();

        private readonly string dbName = "Database.db";

        public void UsarSQLite() {
            var nombre = "Pablo";
            var edad = 32;
            var direccion = "Montevideo"; var salario = 20000.00;

            //Creamos la base de datos(Si existe no se creara)
            if (!File.Exists(dbName)) {
                using (var connect = Conexion) {
                    using (var command = new SQLiteCommand("CREATE TABLE EMPRESA(" +
                                                            "ID          INT       PRIMARY KEY      NOT NULL," +
                                                            "NOMBRE      TEXT                       NOT NULL," +
                                                            "EDAD        INT                        NOT NULL," +
                                                            "DIRECCION   TEXT                       NOT NULL," +
                                                            "SALARIO     REAL)", connect)) {

                        command.ExecuteNonQuery();
                    }
                }
            }

            var id = 0;
            using (var connect = Conexion) {
                using (var command = new SQLiteCommand("SELECT COUNT(ID) FROM EMPRESA", connect)) {
                    var tabla = new DataTable();
                    tabla.Load(command.ExecuteReader());
                    id = Convert.ToInt32(tabla.Rows[0].ItemArray[0]) + 1;
                }
            }

            using (var connect = Conexion) {
                using (var command = new SQLiteCommand("INSERT INTO EMPRESA (ID, NOMBRE, EDAD, DIRECCION, SALARIO) " +
                                        $"VALUES ({id}, '{nombre}', {edad}, '{direccion}', {salario})", connect)) {
                    command.ExecuteNonQuery();
                }
            }

            using (var connect = Conexion) {
                using (var command = new SQLiteCommand("UPDATE EMPRESA set SALARIO = 4500.00 where ID=1", connect)) {
                    command.ExecuteNonQuery();
                }
            }

            using (var connect = Conexion) {
                using (var command = new SQLiteCommand("SELECT * from EMPRESA", connect)) {
                    var tabla = new DataTable();
                    tabla.Load(command.ExecuteReader());
                    foreach (DataRow row in tabla.Rows) {
                        Console.WriteLine(
                            $"{row.Field<int>("ID")} \n" +
                            $"{row.Field<string>("NOMBRE")} \n" +
                            $"{row.Field<int>("EDAD")} \n" +
                            $"{row.Field<string>("DIRECCION")} \n" +
                            $"{row.Field<double>("SALARIO")} \n"
                        );
                    }
                }
            }
            File.Delete(dbName);
        }
    }
}
