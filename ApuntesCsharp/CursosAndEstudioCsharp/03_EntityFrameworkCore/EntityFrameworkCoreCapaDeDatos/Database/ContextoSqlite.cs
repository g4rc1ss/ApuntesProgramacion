using Apuntes.Migrations.LocalDB.Database.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Apuntes.Migrations.LocalDB.Database {
    public class ContextoSqlite :DbContext {
        public DbSet<Usuario> Usuarios { get; set; }

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
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlite(
                    new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true)
                        .Build()
                        .GetConnectionString(nameof(ContextoSqlite)),

                    (opt) => {
                        opt.MigrationsAssembly(typeof(ContextoSqlite).Assembly.FullName);
                    });
            }
        }

        public void CreateDatabase() {
            if (!Database.CanConnect()) {
                Database.Migrate();

                using (var seed = new ContextoSqlite()) {
                    for (var x = 0; x < 200; x++) {
                        seed.Add(new Usuario() {
                            Nombre = "Asier Seeds",
                            Edad = 22
                        });
                    }
                    seed.SaveChanges();
                }
            }
        }
    }
}
