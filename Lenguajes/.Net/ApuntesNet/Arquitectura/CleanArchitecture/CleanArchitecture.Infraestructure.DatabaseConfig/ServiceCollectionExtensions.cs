using CleanArchitecture.Infraestructure.DbConnectionExtension.DependencyInjection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infraestructure.DatabaseConfig;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<EjemploContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(nameof(EjemploContext)));
        });
        services.AddScoped(p => p.GetRequiredService<IDbContextFactory<EjemploContext>>().CreateDbContext());
        services.AddDbContextPool<KeyDataProtectorContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(nameof(KeyDataProtectorContext)));
        });
        services.AddDbConnectionFactory<EjemploContext>(() => new SqlConnection(configuration.GetConnectionString(nameof(EjemploContext))));

        return services;
    }
}
