using Apuntes.Back.Core.Database.Models.Generico;
using Apuntes.Back.Core.SQLite.ModelosBBDD;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Apuntes.Back.Core.Database {
    public class ContextoMSSQL :DbContext, ITablesGenericas {
        public DbSet<ModelosParaBBDD> Usuario { get; set; }
        public DbSet<ModeloDosConClaveForanea> Material { get; set; }

        public ContextoMSSQL() {

        }
        public ContextoMSSQL(DbContextOptions<ContextoMSSQL> options) : base(options) {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if (!optionsBuilder.IsConfigured) {
                var cadenasDeConexion = JObject.Parse(File.ReadAllText("appsettings.json"));
                optionsBuilder.UseSqlServer(
                    (string)cadenasDeConexion["ConnectionStrings"][nameof(ContextoMSSQL)]
                );
            }
        }
    }
}
