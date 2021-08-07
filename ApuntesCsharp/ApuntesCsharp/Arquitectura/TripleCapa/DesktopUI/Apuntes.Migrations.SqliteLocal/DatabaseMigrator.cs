using System.Threading.Tasks;
using Apuntes.BackLocal.DataAccessLayer.Database;
using Microsoft.EntityFrameworkCore;

namespace Apuntes.Migrations.SqliteLocal {
    /// <summary>
    /// Clase para instancias los contextos de los que hay que ejecutar las migraciones para crearlos
    /// </summary>
    public class DatabaseMigrator {
        private readonly ContextoSqlite contextoSqlite;

        public DatabaseMigrator(ContextoSqlite contextoSqlite) {
            this.contextoSqlite = contextoSqlite;
        }

        public Task Migrate() {
            return contextoSqlite.Database.MigrateAsync();
        }

        public Task DeleteDatabase() {
            return contextoSqlite.Database.EnsureDeletedAsync();
        }
    }
}
