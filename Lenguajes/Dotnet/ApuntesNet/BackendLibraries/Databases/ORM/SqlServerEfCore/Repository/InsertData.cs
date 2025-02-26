using SqlServerEfCore.Database;
using SqlServerEfCore.Database.Entities;

namespace SqlServerEfCore.Repository;

public class InsertData(EntityFrameworkSqlServerContext frameworkSqlServerContext)
{
    private readonly EntityFrameworkSqlServerContext _frameworkSqlServerContext = frameworkSqlServerContext;

    internal Task<int> InsertDataAsync()
    {
        Usuario? usuarioAgregar = new()
        {
            Nombre = "Nombre del usuario",
            Edad = 10,
            FechaHoy = DateTime.Now,
            PuebloId = 20,
            PuebloIdNavigation = new Pueblo
            {
                Nombre = "Soria"
            }
        };

        _frameworkSqlServerContext.Usuarios.Add(usuarioAgregar);
        return _frameworkSqlServerContext.SaveChangesAsync();
    }
}
