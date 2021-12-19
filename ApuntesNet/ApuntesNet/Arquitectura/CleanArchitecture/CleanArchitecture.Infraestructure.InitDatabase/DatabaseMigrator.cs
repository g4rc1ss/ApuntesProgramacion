using System.Threading.Tasks;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.InitDatabase;

/// <summary>
/// Clase para instancias los contextos de los que hay que ejecutar las migraciones para crearlos
/// </summary>
public class DatabaseMigrator {
    private readonly EjemploContext _ejemploContext;

    public DatabaseMigrator(EjemploContext webApiPruebaContext) {
        _ejemploContext = webApiPruebaContext;
    }

    public async Task Migrate() {
        await _ejemploContext.Database.MigrateAsync();
    }

    public async Task DeleteDatabase() {
        await _ejemploContext.Database.EnsureDeletedAsync();
    }
}
