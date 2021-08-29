using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DesktopUI.Migrations {
    public class MigrationService : IHostedService {
        private readonly IServiceProvider serviceProvider;

        public MigrationService(IServiceProvider serviceProvider) {
            this.serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken) {
            using (var scope = serviceProvider.CreateScope()) {
                var migrator = scope.ServiceProvider.GetRequiredService<DatabaseMigrator>();
                var initializer = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();

                await migrator.DeleteDatabase();

                await migrator.Migrate();
                await initializer.Initialize(cancellationToken);
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) {
            return Task.CompletedTask;
        }
    }
}
