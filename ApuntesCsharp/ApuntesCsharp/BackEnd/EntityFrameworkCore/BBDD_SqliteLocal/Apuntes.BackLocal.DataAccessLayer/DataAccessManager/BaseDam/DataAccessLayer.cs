using Apuntes.BackLocal.DataAccessLayer.Database;
using Microsoft.EntityFrameworkCore;

namespace Apuntes.BackLocal.DataAccessLayer.DataAccessManager.BaseDam {
    public abstract class DataAccessLayer {
        internal IDbContextFactory<ContextoSqlite> contextSqlite;

        public DataAccessLayer(IDbContextFactory<ContextoSqlite> dbContextFactory) {
            contextSqlite = dbContextFactory;
        }
    }
}
