using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SqlServerEfCore.Database.Models;

namespace SqlServerEfCore.Database {
    public class ContextoMSSQL : DbContext {
        public DbSet<ModelosParaBBDD> Usuario { get; set; }
        public DbSet<ModeloDosConClaveForanea> Material { get; set; }

        public ContextoMSSQL() {

        }
        public ContextoMSSQL(DbContextOptions<ContextoMSSQL> options) : base(options) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PruebaEfCoreSqlServer;Integrated Security=true;");
            }
        }

        public void CreateDatabase() {
            if (!Database.CanConnect()) {
                Database.Migrate();

                using (var context = new ContextoMSSQL()) {
                    context.Add(new ModelosParaBBDD() {
                        Nombre = "Nombre",
                        Apellido = "Apellido",
                        Direccion = "C/ Direccion",
                        Edad = 22,
                        Material = new List<ModeloDosConClaveForanea>() {
                            new ModeloDosConClaveForanea() {
                                Material = "Materiall",
                                TipoMaterial = TipoMaterial.Avion,
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        public void DeleteDatabase() {
            if (Database.CanConnect()) {
                Database.EnsureDeleted();
            }
        }
    }
}
