using DesktopUI.Backend.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace DesktopUI.Backend.Data
{
    public class ContextoSqlServer : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public ContextoSqlServer(DbContextOptions<ContextoSqlServer> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
