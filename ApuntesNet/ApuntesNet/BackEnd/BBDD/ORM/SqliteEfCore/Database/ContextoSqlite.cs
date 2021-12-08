using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using SqliteEfCore.Database.DTO;

namespace SqliteEfCore.Database {
    public partial class ContextoSqlite : DbContext {
        private const string NOMBRE_BBDD = "BBDD_Local.db";

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
            if (File.Exists(NOMBRE_BBDD)) {
                File.Delete(NOMBRE_BBDD);
            }

            Database.Migrate();

            using (var seed = new ContextoSqlite()) {
                for (var x = 0; x < 10; x++) {
                    seed.Pueblos.Add(new Pueblo() {
                        Nombre = $"Pueblo {x + 1}"
                    });
                }

                for (var x = 0; x < 10; x++) {
                    seed.Usuarios.Add(new Usuario() {
                        PuebloId = x + 1,
                        Nombre = "Seeds",
                        Edad = new Random().Next(100)
                    });
                }

                seed.SaveChanges();
            }
        }
    }
}

