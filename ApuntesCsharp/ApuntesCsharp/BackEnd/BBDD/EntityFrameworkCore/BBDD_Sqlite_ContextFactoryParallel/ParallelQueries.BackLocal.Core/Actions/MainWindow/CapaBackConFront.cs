using ParallelQueries.Migrations.LocalDB.Database;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelQueries.BackLocal.Core.Actions.MainWindow {
    public class CapaBackConFront {
        public bool CrearBaseDeDatos() {
            using (var contexto = new ContextoSqlite()) {
                contexto.CreateDatabase();

                if (contexto.Database.CanConnect())
                    return true;
            }
            return false;
        }

        public List<object> CargaDeBaseDeDatos() {
            var baseDeDatos = new List<object>();
            using (var contextoUsers = new ContextoSqlite()) {
                using (var contextoPueblos = ContextFactory.Create()) {
                    var users = default(List<User>);
                    var pueblos = default(List<Pueblo>);
                    Parallel.Invoke(
                        () => {
                            users = (from consulta in contextoUsers.Usuarios
                                     where consulta.Id < 11
                                     select new User() {
                                         Name = consulta.Nombre,
                                         Edad = consulta.Edad
                                     }).ToList();
                        },
                        () => {
                            pueblos = (from query in contextoPueblos.Pueblos
                                       select new Pueblo() {
                                           Nombre = query.Nombre
                                       }).ToList();
                        }
                    );
                    baseDeDatos.AddRange(users);
                    baseDeDatos.AddRange(pueblos);
                }
            }
            return baseDeDatos;
        }
    }
}
