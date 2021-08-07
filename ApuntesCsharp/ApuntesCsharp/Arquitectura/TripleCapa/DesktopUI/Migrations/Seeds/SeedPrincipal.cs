using System.Threading;
using System.Threading.Tasks;
using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Migrations.Seeds {
    public class SeedPrincipal : IDataSeed {
        private readonly IDbContextFactory<ContextoSqlite> dbContextFactory;
        public SeedPrincipal(IDbContextFactory<ContextoSqlite> dbContextFactory) {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task Seed(ContextoSqlite context, CancellationToken cancellationToken = default) {
            await new SeedUser(dbContextFactory.CreateDbContext()).InicializarDatosFavoritos();
        }
    }
}
