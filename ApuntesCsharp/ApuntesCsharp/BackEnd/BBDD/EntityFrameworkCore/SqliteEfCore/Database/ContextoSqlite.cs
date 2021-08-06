using Microsoft.EntityFrameworkCore;
using SqliteEfCore.Database.Sqlite;

namespace SqliteEfCore.Database {
    public partial class ContextoSqlite : DbContext {

        public ContextoSqlite() {

        }
        public ContextoSqlite(DbContextOptions optionsBuilder) : base(optionsBuilder) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlite("Data Source=BBDD_Local.db");
            }
        }

        public void CreateDatabase() {
            if (!Database.CanConnect()) {
                Database.Migrate();

                using (var seed = new ContextoSqlite()) {
                    for (var x = 0; x < 200; x++) {
                        seed.Add(new Usuario() {
                            Nombre = "Seeds",
                            Edad = 22
                        });
                    }

                    for (var x = 0; x < 200; x++) {
                        seed.Add(new Pueblo() {
                            Nombre = $"Pueblo {x + 1}"
                        });
                    }

                    seed.SaveChanges();
                }
            }
        }
    }
}

