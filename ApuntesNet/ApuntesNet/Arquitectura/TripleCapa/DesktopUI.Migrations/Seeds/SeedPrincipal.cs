using System.Threading;
using System.Threading.Tasks;
using DesktopUI.Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace DesktopUI.Migrations.Seeds {
    public class SeedPrincipal : IDataSeed {
        private readonly IDbContextFactory<ContextoSqlServer> dbContextFactory;
        public SeedPrincipal(IDbContextFactory<ContextoSqlServer> dbContextFactory) {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task Seed(ContextoSqlServer context, CancellationToken cancellationToken = default) {
            await new SeedUser(dbContextFactory.CreateDbContext()).InicializarDatosFavoritos();
        }
    }
}
