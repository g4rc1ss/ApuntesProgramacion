using Apuntes.Back.Core.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Apuntes.Migrations.SqlServer {
    /// <summary>
    /// Clase para instancias los contextos de los que hay que ejecutar las migraciones para crearlos
    /// </summary>
    public class DatabaseMigrator {
        private readonly ContextoMSSQL contextoMSSQL;

        public DatabaseMigrator(ContextoMSSQL contextoMSSQL) {
            this.contextoMSSQL = contextoMSSQL;
        }

        public Task Migrate() {
            return contextoMSSQL.Database.MigrateAsync();
        }
    }
}
