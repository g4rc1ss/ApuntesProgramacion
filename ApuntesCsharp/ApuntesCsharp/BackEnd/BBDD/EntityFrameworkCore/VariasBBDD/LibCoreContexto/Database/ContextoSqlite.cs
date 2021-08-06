using System.IO;
using Apuntes.Back.Core.Database.Models.Generico;
using Apuntes.Back.Core.SQLite.ModelosBBDD;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace Apuntes.Back.Core.Database {
    public class ContextoSqlite : DbContext, ITablesGenericas {
        public DbSet<ModelosParaBBDD> Usuario { get; set; }
        public DbSet<ModeloDosConClaveForanea> Material { get; set; }

        public ContextoSqlite() {

        }
        public ContextoSqlite(DbContextOptions<ContextoSqlite> options) : base(options) {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                var cadenasDeConexion = JObject.Parse(File.ReadAllText("appsettings.json"));
                optionsBuilder.UseSqlite(
                    (string)cadenasDeConexion["ConnectionStrings"][nameof(ContextoSqlite)]
                );
            }
        }
    }
}
