using Microsoft.EntityFrameworkCore;
using SqliteEfCore.Database.Sqlite;

namespace SqliteEfCore.Database {
    public partial class ContextoSqlite {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pueblo> Pueblos { get; set; }
    }
}
