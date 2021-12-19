using System.Threading.Tasks;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.Migrations;

/// <summary>
/// Clase para instancias los contextos de los que hay que ejecutar las migraciones para crearlos
/// </summary>
public class DatabaseMigrator {
    private readonly EjemploContext _ejemploContext;

    public DatabaseMigrator(EjemploContext webApiPruebaContext) {
        _ejemploContext = webApiPruebaContext;
    }

    public Task Migrate() {
        return _ejemploContext.Database.MigrateAsync();
    }

    public Task DeleteDatabase() {
        return _ejemploContext.Database.EnsureDeletedAsync();
    }
}
