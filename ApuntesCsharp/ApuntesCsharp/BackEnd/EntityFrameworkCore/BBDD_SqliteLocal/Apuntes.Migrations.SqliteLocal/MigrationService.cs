using Garciss.Core.Common.Helper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Apuntes.Migrations.SqliteLocal {
    public class MigrationService :IHostedService {
        private readonly IServiceProvider serviceProvider;

        public MigrationService(IServiceProvider serviceProvider) {
            this.serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken) {
            using (var scope = serviceProvider.CreateScope()) {
                var migrator = scope.ServiceProvider.GetRequiredService<DatabaseMigrator>();
                var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();

                if (Helper.IsDevelopment) await migrator.DeleteDatabase();

                await migrator.Migrate();
                await initializer.Initialize(cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) {
            return Task.CompletedTask;
        }
    }
}
