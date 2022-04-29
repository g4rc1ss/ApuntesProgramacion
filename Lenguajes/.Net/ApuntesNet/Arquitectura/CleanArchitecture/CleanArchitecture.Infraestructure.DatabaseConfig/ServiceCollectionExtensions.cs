using CleanArchitecture.Infraestructure.DataDapper;
using CleanArchitecture.Infraestructure.DataDapper.Contexts;
using CleanArchitecture.Infraestructure.DataEjemplo;
using CleanArchitecture.Infraestructure.DataEntityFramework.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infraestructure.DatabaseConfig;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
    {
        // Add EntityFramework
        services.AddAutoMapper(typeof(EjemploContext));
        services.AddEntityFrameworkRepositories(configuration);
        services.AddIdentityEntityFramework(configuration);

        // Agregar Dapper
        services.AddAutoMapper(typeof(EjemploDapperDatabase));
        services.AddDapperRepositories(configuration.GetConnectionString(nameof(EjemploContext)));

        return services;
    }
}
