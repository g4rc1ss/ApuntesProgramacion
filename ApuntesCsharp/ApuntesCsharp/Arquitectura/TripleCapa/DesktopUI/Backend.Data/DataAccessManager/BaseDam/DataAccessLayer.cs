using Microsoft.EntityFrameworkCore;

namespace Backend.Data.DataAccessManager.BaseDam {
    public abstract class DataAccessLayer {
        internal IDbContextFactory<ContextoSqlite> contextSqlite;

        public DataAccessLayer(IDbContextFactory<ContextoSqlite> dbContextFactory) {
            contextSqlite = dbContextFactory;
        }
    }
}
