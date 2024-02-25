using SqlServerEfCore.Database;

namespace SqlServerEfCore.Repository;

internal class DeleteData(EntityFrameworkSqlServerContext frameworkSqlServerContext)
{
    private readonly EntityFrameworkSqlServerContext _frameworkSqlServerContext = frameworkSqlServerContext;

    internal Task<int> DeleteDataAsync()
    {
        var usuarios = (from user in _frameworkSqlServerContext.Usuarios
                        where user.Id == 2
                        select user).ToList();
        _frameworkSqlServerContext.RemoveRange(usuarios);
        return _frameworkSqlServerContext.SaveChangesAsync();
    }
}
