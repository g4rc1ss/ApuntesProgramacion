using System.Collections.Generic;
using System.Linq;
using SqliteEfCore.Database;

namespace SqliteEfCore.Core {
    public class EjecutarQueries {
        public static bool CrearBaseDeDatos() {
            using (var contexto = new ContextoSqlite()) {
                contexto.CreateDatabase();

                if (contexto.Database.CanConnect()) {
                    return true;
                }
            }
            return false;
        }

        public static List<User> CargarUsuarios() {
            using (var context = new ContextoSqlite()) {
                var users = (from consulta in context.Usuarios
                             where consulta.Id < 11
                             select new User() {
                                 Name = consulta.Nombre,
                                 Edad = consulta.Edad
                             }).ToList();
                return users;
            }
        }

        public static List<Pueblo> CargarPueblos() {
            using (var context = new ContextoSqlite()) {
                var pueblos = (from query in context.Pueblos
                               select new Pueblo() {
                                   Nombre = query.Nombre
                               }).ToList();
                return pueblos;
            }
        }
    }
}
