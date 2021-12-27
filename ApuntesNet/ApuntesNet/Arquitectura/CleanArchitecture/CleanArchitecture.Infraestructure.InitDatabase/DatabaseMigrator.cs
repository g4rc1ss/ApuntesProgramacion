using CleanArchitecture.Dominio;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.InitDatabase;

/// <summary>
/// Clase para instancias los contextos de los que hay que ejecutar las migraciones para crearlos
/// </summary>
public class DatabaseMigrator
{
    private readonly EjemploContext _ejemploContext;

    public DatabaseMigrator(EjemploContext ejemploContext)
    {
        _ejemploContext = ejemploContext;
    }

    public Task Migrate()
    {
        return _ejemploContext.Database.MigrateAsync();
    }

    public Task DeleteDatabase()
    {
        return _ejemploContext.Database.EnsureDeletedAsync();
    }
}
