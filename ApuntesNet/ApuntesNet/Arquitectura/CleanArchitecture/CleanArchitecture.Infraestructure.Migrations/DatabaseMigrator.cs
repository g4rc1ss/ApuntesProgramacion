using System.Threading.Tasks;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Migrations {
    /// <summary>
    /// Clase para instancias los contextos de los que hay que ejecutar las migraciones para crearlos
    /// </summary>
    public class DatabaseMigrator {
        private readonly WebApiPruebaContext webApiPruebaContext;

        public DatabaseMigrator(WebApiPruebaContext webApiPruebaContext) {
            this.webApiPruebaContext = webApiPruebaContext;
        }

        public Task Migrate() {
            return webApiPruebaContext.Database.MigrateAsync();
        }

        public Task DeleteDatabase() {
            return webApiPruebaContext.Database.EnsureDeletedAsync();
        }
    }
}
