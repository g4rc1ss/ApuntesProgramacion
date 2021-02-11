```Csharp
 // Creamos la Base de datos con Update-Database en la linea de comandos de nuget
            // Agregamos contenido
            using (var db = new ContextoSqlite()) {
                Console.WriteLine("Insertando Datos...");
                db.Add(new ModelosParaBBDD {
                    Nombre = "Prueba",
                    Apellido = "Pruebasssssssss",
                    Direccion = "La direccion es la direccion :P",
                    Edad = 13
                });
                db.SaveChanges();

                // Leemos el contenido mediante una consulta Linq
                Console.WriteLine("Leemos el contenido de la base de datos creada");
                var usuarios = (from usuario in db.Usuario
                                orderby usuario.ID
                                select usuario).First();

                // Si se va a interpolar, osea usar el $"{}" Se ha de usar la intruccion FromSqlInterpolated
                // Para prevenir los ataques de SQLI
                // Con esta intruccion tambien se pueden ejecutar procedimientos almacenados etc.
                var usuariosDos = (from usuario in db.Usuario.FromSqlInterpolated($"Select * from Usuario where ID = {usuarios.ID}")
                                  select usuario).ToList();

                // Updateamos el contenido ya existente
                Console.WriteLine("Updateando el contenido");
                usuarios.Apellido = "APELLIDO MODIFICADOOOOOOOOOOO";
                db.SaveChanges();

                // Borramos el registro instanciado en la bbdd
                Console.WriteLine($"Borrando el contenido de {usuarios.ID}");
                db.Remove(usuarios);
                db.SaveChanges();
            }
```