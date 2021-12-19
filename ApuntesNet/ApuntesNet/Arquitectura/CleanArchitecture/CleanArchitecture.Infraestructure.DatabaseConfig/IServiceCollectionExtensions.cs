using CleanArchitecture.Infraestructure.DatabaseConfig.DbConnectionExtension;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infraestructure.DatabaseConfig {
    public static class IServiceCollectionExtensions {
        public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContextFactory<EjemploContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString(nameof(EjemploContext)));
            });
            services.AddScoped(p => p.GetRequiredService<IDbContextFactory<EjemploContext>>().CreateDbContext());
            services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>(service =>
                new DbConnectionFactory(() => service.GetRequiredService<EjemploContext>().Database.GetDbConnection()));

            return services;
        }
    }
}
