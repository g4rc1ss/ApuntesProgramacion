using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ParallelQueries.Migrations.LocalDB.Database.Sqlite;
using System.Threading.Tasks;

namespace ParallelQueries.Migrations.LocalDB.Database {
    public partial class ContextoSqlite :DbContext {

        public ContextoSqlite() {

        }
        public ContextoSqlite(DbContextOptions optionsBuilder) : base(optionsBuilder) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
#if DEBUG
            // Instalamos el paquete nuget: 'Microsoft.Extensions.Logging.Debug'
            // Se registran en el output de debug
            optionsBuilder.UseLoggerFactory(
                new Microsoft.Extensions.Logging.LoggerFactory(new[] {
                    new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
                })
            );
#endif
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite(
                    new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true)
                    .Build()
                    .GetConnectionString(nameof(ContextoSqlite)),
                    (opt) => {
                        opt.MigrationsAssembly(typeof(ContextoSqlite).Assembly.FullName);
                    });
        }

        public void CreateDatabase() {
            if (!Database.CanConnect()) {
                Database.Migrate();

                using (var seedUser = new ContextoSqlite()) {
                    using (var seedPueblo = ContextFactory.Create()) {
                        for (var x = 0; x < 200; x++)
                            seedUser.Add(new Usuario() {
                                Nombre = "Asier Seeds",
                                Edad = 22
                            });

                        for (var x = 0; x < 200; x++)
                            seedPueblo.Add(new Pueblo() {
                                Nombre = $"Pueblo {x + 1}"
                            });

                        Parallel.Invoke(
                            () => seedUser.SaveChanges(),
                            () => seedPueblo.SaveChanges()
                        );
                    }
                }
            }
        }
    }
}
