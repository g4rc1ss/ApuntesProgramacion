using Apuntes.BackLocal.DataAccessLayer.Database;
using Apuntes.BackLocal.DataAccessLayer.Database.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Apuntes.BackLocal.DataAccessLayer.DataAccessManager {
    public class UserDam :BaseDam.DataAccessLayer {
        public UserDam(IDbContextFactory<ContextoSqlite> dbContextFactory) : base(dbContextFactory) {
        }

        public List<Usuario> GetAllUsers() {
            using (var context = contextSqlite.CreateDbContext()) {
                return (from user in context.Usuarios
                        orderby user.Id
                        select user).ToList();
            }
        }

        public List<Usuario> GetAllUsersWithEdad(int edad) {
            using (var context = contextSqlite.CreateDbContext()) {
                return (from user in context.Usuarios
                        where user.Edad == edad
                        orderby user.Id
                        select user).ToList();
            }
        }
    }
}
