using SqlServerEfCore.Database;
using SqlServerEfCore.Database.Entities;

namespace SqlServerEfCore.Repository;

internal class DeleteData(EntityFrameworkSqlServerContext frameworkSqlServerContext)
{
    internal Task<int> DeleteDataAsync()
    {
        List<Usuario>? usuarios = [..
            from user in frameworkSqlServerContext.Usuarios
            where user.Id == 2
            select user];
        frameworkSqlServerContext.RemoveRange(usuarios);
        return frameworkSqlServerContext.SaveChangesAsync();
    }
}