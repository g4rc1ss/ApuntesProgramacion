using Apuntes.Back.Core.Database;
using Apuntes.Back.Core.SQLite.ModelosBBDD;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Runtime.CompilerServices;


namespace PrincipalConMainDeProyecto {
    public static class EjecutarConsultasSqlite {
        public static void EjecutarSentenciasLinqAndSQL() {
            // Creamos la Base de datos con Update-Database en la linea de comandos de nuget
            // Agregamos contenido
            using (var db = new ContextoMSSQL()) {
                Console.WriteLine("Insertando Datos...");
                var modeloBBDD = new ModelosParaBBDD {
                    Nombre = "Prueba",
                    Apellido = "Pruebasssssssss",
                    Direccion = "La direccion es la direccion :P",
                    Edad = 13
                };
                db.Add(modeloBBDD);
                db.SaveChanges();

                Console.WriteLine($"Insertando Datos con sentencia SQL");
                var sentencia = FormattableStringFactory.Create("INSERT INTO Usuario (Nombre, Apellido, Direccion, Edad, FechaHoy) values " +
                    $"('{"INSERT INTO CON SQL"}', '{modeloBBDD.Apellido}', '{modeloBBDD.Direccion}', {modeloBBDD.Edad}, '{modeloBBDD.FechaHoy}')");
                db.Database.ExecuteSqlInterpolated(sentencia);

                // Leemos el contenido mediante una consulta Linq
                Console.WriteLine("Leemos el contenido de la base de datos creada");
                var usuarios = (from usuario in db.Usuario
                                orderby usuario.ID
                                select usuario).First();

                // Si se va a interpolar, osea usar el $"{}" Se ha de usar la intruccion FromSqlInterpolated
                // Para prevenir los ataques de SQLI
                // Con esta intruccion tambien se pueden ejecutar procedimientos almacenados etc.
                var usuariosDos = (from usuario in db.Usuario.FromSqlInterpolated($"Select * from Usuario")
                                   select usuario).ToList();

                // Updateamos el contenido ya existente
                Console.WriteLine("Updateando el contenido");
                usuarios.Apellido = "APELLIDO MODIFICADOOOOOOOOOOO";
                db.SaveChanges();

                // Borramos el registro instanciado en la bbdd
                Console.WriteLine($"Borrando el contenido de {usuarios.ID}");
                var consultaParaBorrado = (from sql in db.Usuario
                                           where sql.ID == usuarios.ID
                                           select sql).ToList();
                if (consultaParaBorrado.Count == 1)
                    db.Usuario.Remove(consultaParaBorrado[0]);
                else if (consultaParaBorrado.Count > 1)
                    db.Usuario.RemoveRange(consultaParaBorrado);
                db.SaveChanges();

                Console.WriteLine($"Borrando todas las filas de la tabla con sentencia SQL");
                db.Database.ExecuteSqlRaw("DELETE FROM Usuario;");
            }
        }
    }
}
