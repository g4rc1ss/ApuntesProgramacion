using Microsoft.EntityFrameworkCore;

namespace Backend.Data.DataAccessManager.BaseDam {
    public abstract class DataAccessLayer {
        internal IDbContextFactory<ContextoSqlServer> contextSqlite;

        public DataAccessLayer(IDbContextFactory<ContextoSqlServer> dbContextFactory) {
            contextSqlite = dbContextFactory;
        }
    }
}
