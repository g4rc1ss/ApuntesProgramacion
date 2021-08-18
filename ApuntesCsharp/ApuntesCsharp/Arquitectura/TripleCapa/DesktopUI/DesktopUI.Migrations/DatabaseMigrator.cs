using System.Threading.Tasks;
using DesktopUI.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace DesktopUI.Migrations {
    /// <summary>
    /// Clase para instancias los contextos de los que hay que ejecutar las migraciones para crearlos
    /// </summary>
    public class DatabaseMigrator {
        private readonly ContextoSqlServer contextoSqlite;

        public DatabaseMigrator(ContextoSqlServer contextoSqlite) {
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
