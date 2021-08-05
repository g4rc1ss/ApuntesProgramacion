using Apuntes.BackLocal.DataAccessLayer.Database.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Apuntes.BackLocal.DataAccessLayer.Database {
    public class ContextoSqlite :DbContext {
        public DbSet<Usuario> Usuarios { get; set; }

        public ContextoSqlite(DbContextOptions<ContextoSqlite> contextOptions) : base(contextOptions) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }
}
