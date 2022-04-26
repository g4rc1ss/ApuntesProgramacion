using CleanArchitecture.Infraestructure.DatabaseConfig;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.InitDatabase;

/// <summary>
/// Clase para instancias los contextos de los que hay que ejecutar las migraciones para crearlos
/// </summary>
public class DatabaseMigrator
{
    private readonly EjemploContext _ejemploContext;
    private readonly KeyDataProtectorContext _keyDataProtectorContext;

    public DatabaseMigrator(EjemploContext ejemploContext, KeyDataProtectorContext keyDataProtectorContext)
    {
        _ejemploContext = ejemploContext;
        _keyDataProtectorContext = keyDataProtectorContext;
    }

    public Task MigrateEjemploContext()
    {
        return _ejemploContext.Database.MigrateAsync();
    }

    public Task DeleteDatabaseEjemploContext()
    {
        return _ejemploContext.Database.EnsureDeletedAsync();
    }

    public Task MigrateKeysDataProtectorContext()
    {
        return _keyDataProtectorContext.Database.MigrateAsync();
    }

    public Task DeleteKeysDataProtectorContext()
    {
        return _keyDataProtectorContext.Database.EnsureDeletedAsync();
    }
}
