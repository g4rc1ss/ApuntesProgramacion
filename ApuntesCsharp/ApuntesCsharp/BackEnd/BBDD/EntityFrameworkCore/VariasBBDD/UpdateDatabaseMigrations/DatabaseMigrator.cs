using Apuntes.Back.Core.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Apuntes.Migrations.SqlServer {
    /// <summary>
    /// Clase para instancias los contextos de los que hay que ejecutar las migraciones para crearlos
    /// </summary>
    public class DatabaseMigrator {
        private readonly ContextoSqlite contextoSqlite;
        private readonly ContextoMSSQL contextoMSSQL;

        public DatabaseMigrator(ContextoMSSQL contextoMSSQL, ContextoSqlite contextoSqlite) {
            this.contextoSqlite = contextoSqlite;
            this.contextoMSSQL = contextoMSSQL;
        }

        public void Migrate() {
            Parallel.Invoke(
                () => contextoSqlite.Database.Migrate(),
                () => contextoMSSQL.Database.Migrate()
            );
        }
    }
}
