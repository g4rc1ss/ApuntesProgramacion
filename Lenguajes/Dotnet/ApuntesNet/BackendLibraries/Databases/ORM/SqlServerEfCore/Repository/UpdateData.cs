using SqlServerEfCore.Database;
using SqlServerEfCore.Database.Entities;

namespace SqlServerEfCore.Repository;

public class UpdateData(EntityFrameworkSqlServerContext frameworkSqlServerContext)
{
    private readonly EntityFrameworkSqlServerContext _frameworkSqlServerContext = frameworkSqlServerContext;

    internal Task<int> UpdateDataAsync()
    {
        int idPueblo = 1;

        Usuario? usuario = (
            from user in _frameworkSqlServerContext.Usuarios
            where user.PuebloIdNavigation.Id == idPueblo
            select user).Single();

        usuario.Nombre = "cnifvbdilcbsuyvrg";

        _frameworkSqlServerContext.Update(usuario);
        return _frameworkSqlServerContext.SaveChangesAsync();
    }
}