using Microsoft.EntityFrameworkCore;
using SqlServerEfCore.Database;
using SqlServerEfCore.Database.Entities;

namespace SqlServerEfCore.Repository
{
    internal class SelectData
    {
        private readonly EntityFrameworkSqlServerContext _frameworkSqlServerContext;

        public SelectData(EntityFrameworkSqlServerContext frameworkSqlServerContext)
        {
            _frameworkSqlServerContext = frameworkSqlServerContext;
        }

        public Task<List<Usuario>> SelectDataAsync()
        {
            return (from usuario in _frameworkSqlServerContext.Usuarios
                    join pueblo in _frameworkSqlServerContext.Pueblos on usuario.PuebloId equals pueblo.Id
                    select usuario).ToListAsync();
        }
    }
}
