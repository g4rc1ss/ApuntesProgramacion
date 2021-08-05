using System;
using System.Data;
using System.IO;

namespace BasesDeDatos.SQLite {
    public class UsarBBDD_SQLite {
        public void UsarSQLite() {
            var nombre = "Pablo";
            var edad = 32;
            var direccion = "Montevideo"; var salario = 20000.00;
            var baseDatos = new SQLiteDB();
            //Creamos la base de datos(Si existe no se creara)
            if (!baseDatos.IsCreateDatabase()) {
                baseDatos.CreateDatabase(
                query: "CREATE TABLE EMPRESA(" +
                    "ID          INT       PRIMARY KEY      NOT NULL," +
                    "NOMBRE      TEXT                       NOT NULL," +
                    "EDAD        INT                        NOT NULL," +
                    "DIRECCION   TEXT                       NOT NULL," +
                    "SALARIO     REAL)"
                );
            } else {
                var key = File.ReadAllBytes("Key.aes");
                var iV = File.ReadAllBytes("IV.aes");
                new AESHelper().DesencriptarFichero(baseDatos.DBName, key, iV);
            }


            var id = baseDatos.MaxID("ID", "EMPRESA");

            baseDatos.UpdateOrInsert(
                    "INSERT INTO EMPRESA (ID, NOMBRE, EDAD, DIRECCION, SALARIO) " +
                    $"VALUES ({id}, '{nombre}', {edad}, '{direccion}', {salario})"
            );

            baseDatos.UpdateOrInsert("UPDATE EMPRESA set SALARIO = 4500.00 where ID=1");

            using (var resultadoSelect = baseDatos.Select("SELECT * from EMPRESA"))
                foreach (DataRow row in resultadoSelect.Rows)
                    Console.WriteLine(
                        $"{row.Field<int>("ID")} \n" +
                        $"{row.Field<string>("NOMBRE")} \n" +
                        $"{row.Field<int>("EDAD")} \n" +
                        $"{row.Field<string>("DIRECCION")} \n" +
                        $"{row.Field<double>("SALARIO")} \n"
                    );

            var cifrar = new AESHelper();
            cifrar.EncriptarFichero(baseDatos.DBName);
            File.WriteAllBytes("Key.aes", cifrar.Key);
            File.WriteAllBytes("IV.aes", cifrar.IV);
            File.Delete(baseDatos.DBName);
            Console.Read();
        }
    }
}
