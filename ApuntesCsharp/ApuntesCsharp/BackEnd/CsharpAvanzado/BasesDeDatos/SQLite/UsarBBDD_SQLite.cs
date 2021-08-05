using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;

namespace BasesDeDatos.SQLite {
    public class UsarBBDD_SQLite {
        private SQLiteConnection Conexion => new SQLiteConnection(string.Format($"Data Source={dbName};Version=3;")).OpenAndReturn();
        private string dbName = "Database.db";
        private string dbNameCrypt = "Database.db.crypt";

        public void UsarSQLite() {
            var nombre = "Pablo";
            var edad = 32;
            var direccion = "Montevideo"; var salario = 20000.00;

            //Creamos la base de datos(Si existe no se creara)
            if (!File.Exists(dbNameCrypt)) {
                using (var connect = Conexion) {
                    using (var command = new SQLiteCommand("CREATE TABLE EMPRESA(" +
                    "ID          INT       PRIMARY KEY      NOT NULL," +
                    "NOMBRE      TEXT                       NOT NULL," +
                    "EDAD        INT                        NOT NULL," +
                    "DIRECCION   TEXT                       NOT NULL," +
                    "SALARIO     REAL)", connect))
                        command.ExecuteNonQuery();
                }
            } else {
                var key = File.ReadAllBytes("Key.aes");
                var iV = File.ReadAllBytes("IV.aes");
                using (var aesAlg = Aes.Create()) {
                    aesAlg.Key = key;
                    aesAlg.IV = iV;

                    // Create an encryptor to perform the stream transform.
                    using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
                    using (var fileStreamCrypt = new FileStream(dbNameCrypt, FileMode.Open, FileAccess.Read))
                    using (var fileStreamOut = new FileStream(dbName, FileMode.OpenOrCreate, FileAccess.Write))
                    using (var decryptStream = new CryptoStream(fileStreamCrypt, decryptor, CryptoStreamMode.Read))
                        for (int data; (data = decryptStream.ReadByte()) != -1;)
                            fileStreamOut.WriteByte((byte)data);
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
                    foreach (DataRow row in tabla.Rows)
                        Console.WriteLine(
                            $"{row.Field<int>("ID")} \n" +
                            $"{row.Field<string>("NOMBRE")} \n" +
                            $"{row.Field<int>("EDAD")} \n" +
                            $"{row.Field<string>("DIRECCION")} \n" +
                            $"{row.Field<double>("SALARIO")} \n"
                        );
                }
            }
            using (var aesAlg = Aes.Create()) {
                using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
                using (var fileStreamOutput = new FileStream(dbNameCrypt, FileMode.Create, FileAccess.Write))
                using (var cryptStream = new CryptoStream(fileStreamOutput, encryptor, CryptoStreamMode.Write))
                using (var fileStreamInput = new FileStream(dbName, FileMode.Open, FileAccess.Read))
                    for (int data; (data = fileStreamInput.ReadByte()) != -1;)
                        cryptStream.WriteByte((byte)data);
                File.WriteAllBytes("Key.aes", aesAlg.Key);
                File.WriteAllBytes("IV.aes", aesAlg.IV);
            }
            File.Delete(dbName);
            Console.Read();
        }
    }
}
