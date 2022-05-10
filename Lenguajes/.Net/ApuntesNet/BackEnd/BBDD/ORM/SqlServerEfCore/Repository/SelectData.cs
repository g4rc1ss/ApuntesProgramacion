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

        public async Task<List<Usuario>> SelectDataAsync()
        {
            var pueblos = await _frameworkSqlServerContext.Pueblos.ToArrayAsync();
            var usuarios = await _frameworkSqlServerContext.Usuarios.ToArrayAsync();
            var pueblosInclude = await _frameworkSqlServerContext.Pueblos.Include(x => x.Usuarios).ToArrayAsync();
            var usuariosInclude = await _frameworkSqlServerContext.Usuarios.Include(x => x.PuebloIdNavigation).ToArrayAsync();


            return await (from usuario in _frameworkSqlServerContext.Usuarios
                          join pueblo in _frameworkSqlServerContext.Pueblos on usuario.PuebloId equals pueblo.Id
                          select usuario).ToListAsync();
        }
    }
}
