using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ParallelQueries.Migrations.LocalDB.Database {
    public static class ContextFactory {
        public static ContextoSqlite Create() {
            var options = new DbContextOptionsBuilder<ContextoSqlite>().UseSqlite(
                    new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true)
                    .Build()
                    .GetConnectionString(nameof(ContextoSqlite)),
                    (opt) => {
                        opt.MigrationsAssembly(typeof(ContextoSqlite).Assembly.FullName);
                    })
                .Options;
            return new ContextoSqlite(options);
        }
    }
}
