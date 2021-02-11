using Apuntes.Migrations.LocalDB.Database;
using Apuntes.Migrations.LocalDB.Database.Sqlite;
using System.Collections.Generic;
using System.Linq;

namespace Apuntes.BackLocal.Core.Actions.MainWindow {
    public class CapaBackConFront {
        public bool CrearBaseDeDatos() {
            using (var contexto = new ContextoSqlite()) {
                contexto.CreateDatabase();

                if (contexto.Database.CanConnect())
                    return true;
            }
            return false;
        }
        public List<User> CargaDeBaseDeDatos() {
            using (var context = new ContextoSqlite()) {
                var baseDeDatos = (from consulta in context.Usuarios
                                   where consulta.Id < 11
                                   select new User() {
                                       Name = consulta.Nombre,
                                       Edad = consulta.Edad
                                   }).ToList();
                return baseDeDatos;
            }
        }
    }
}
