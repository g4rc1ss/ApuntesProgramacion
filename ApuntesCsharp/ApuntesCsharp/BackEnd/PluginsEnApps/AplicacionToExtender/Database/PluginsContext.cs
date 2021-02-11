using AplicacionToExtender.Database.DatabaseEntities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.IO;

namespace AplicacionToExtender.Database {
    internal class PluginsContext :DbContext {

        public DbSet<Plugin> Plugins { get; set; }

        public PluginsContext() {

        }

        public PluginsContext(DbContextOptions<PluginsContext> options) : base(options) {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

#if DEBUG
            optionsBuilder.UseLoggerFactory(
                new Microsoft.Extensions.Logging.LoggerFactory(new[] {
                    new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
                })
            );
#endif
            if (!optionsBuilder.IsConfigured) {
                var cadenasDeConexion = JObject.Parse(File.ReadAllText("appsettings.json"));
                optionsBuilder.UseSqlite(
                    (string)cadenasDeConexion["ConnectionStrings"][nameof(PluginsContext)]
                );
            }
        }
    }
}
