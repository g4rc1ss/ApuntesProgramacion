using Microsoft.EntityFrameworkCore;
using ParallelQueries.Migrations.LocalDB.Database.Sqlite;

namespace ParallelQueries.Migrations.LocalDB.Database {
    public partial class ContextoSqlite {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pueblo> Pueblos { get; set; }
    }
}
