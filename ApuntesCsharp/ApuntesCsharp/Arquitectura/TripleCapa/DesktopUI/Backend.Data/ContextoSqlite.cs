using Backend.Data.Database.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data {
    public class ContextoSqlite : DbContext {
        public DbSet<Usuario> Usuarios { get; set; }

        public ContextoSqlite(DbContextOptions<ContextoSqlite> contextOptions) : base(contextOptions) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}
