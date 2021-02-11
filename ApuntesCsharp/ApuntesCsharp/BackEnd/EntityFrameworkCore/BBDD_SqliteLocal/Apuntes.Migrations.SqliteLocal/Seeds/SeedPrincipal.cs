using Apuntes.BackLocal.DataAccessLayer.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Apuntes.Migrations.SqliteLocal.Seeds {
    public class SeedPrincipal :IDataSeed {
        private readonly IDbContextFactory<ContextoSqlite> dbContextFactory;
        public SeedPrincipal(IDbContextFactory<ContextoSqlite> dbContextFactory) {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task Seed(ContextoSqlite context, CancellationToken cancellationToken = default) {
            await new SeedUser(dbContextFactory.CreateDbContext(), dbContextFactory).InicializarDatosFavoritos();
        }
    }
}
