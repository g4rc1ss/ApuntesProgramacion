using Microsoft.EntityFrameworkCore;
using SqlServerEfCore.Database;

namespace MigrationsSqlServer
{
    internal class MigrationService
    {
        private readonly EntityFrameworkSqlServerContext _context;

        public MigrationService(EntityFrameworkSqlServerContext context)
        {
            _context = context;
        }

        public async Task MigrateApplicationAsync()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.MigrateAsync();
        }

        public Task InitializeDatabase()
        {
            return Task.CompletedTask;
        }
    }
}
