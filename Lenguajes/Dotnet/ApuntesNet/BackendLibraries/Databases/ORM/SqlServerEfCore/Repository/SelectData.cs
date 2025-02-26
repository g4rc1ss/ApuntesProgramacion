using Microsoft.EntityFrameworkCore;


using SqlServerEfCore.Database;
using SqlServerEfCore.Database.Entities;

namespace SqlServerEfCore.Repository;

internal class SelectData(EntityFrameworkSqlServerContext frameworkSqlServerContext)
{
    private readonly EntityFrameworkSqlServerContext _frameworkSqlServerContext = frameworkSqlServerContext;

    public async Task<List<Usuario>> SelectDataAsync()
    {
        Pueblo[]? pueblos = await _frameworkSqlServerContext.Pueblos.ToArrayAsync();
        Usuario[]? usuarios = await _frameworkSqlServerContext.Usuarios.ToArrayAsync();
        Pueblo[]? pueblosInclude = await _frameworkSqlServerContext.Pueblos.Include(x => x.Usuarios).ToArrayAsync();
        Usuario[]? usuariosInclude = await _frameworkSqlServerContext.Usuarios.Include(x => x.PuebloIdNavigation).ToArrayAsync();


        return await (from usuario in _frameworkSqlServerContext.Usuarios
                      join pueblo in _frameworkSqlServerContext.Pueblos on usuario.PuebloId equals pueblo.Id
                      select usuario).ToListAsync();
    }
}
