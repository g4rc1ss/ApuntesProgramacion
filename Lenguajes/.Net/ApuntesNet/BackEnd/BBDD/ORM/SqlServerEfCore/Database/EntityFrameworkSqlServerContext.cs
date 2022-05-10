using Microsoft.EntityFrameworkCore;
using SqlServerEfCore.Database.Entities;

namespace SqlServerEfCore.Database
{
    public partial class EntityFrameworkSqlServerContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pueblo> Pueblos { get; set; }

        public EntityFrameworkSqlServerContext(DbContextOptions optionsBuilder) : base(optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

