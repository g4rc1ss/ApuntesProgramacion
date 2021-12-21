using Microsoft.EntityFrameworkCore;

namespace DesktopUI.Backend.Data.DataAccessManager.BaseDam
{
    public abstract class DataAccessLayer
    {
        internal IDbContextFactory<ContextoSqlServer> contexto;

        public DataAccessLayer(IDbContextFactory<ContextoSqlServer> dbContextFactory)
        {
            contexto = dbContextFactory;
        }
    }
}
