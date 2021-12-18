using System.Threading.Tasks;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.Migrations;

/// <summary>
/// Clase para instancias los contextos de los que hay que ejecutar las migraciones para crearlos
/// </summary>
public class DatabaseMigrator {
    private readonly EjemploContext webApiPruebaContext;

    public DatabaseMigrator(EjemploContext webApiPruebaContext) {
        this.webApiPruebaContext = webApiPruebaContext;
    }

    public Task Migrate() {
        return webApiPruebaContext.Database.MigrateAsync();
    }

    public Task DeleteDatabase() {
        return webApiPruebaContext.Database.EnsureDeletedAsync();
    }
}
