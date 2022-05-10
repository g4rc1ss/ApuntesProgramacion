using CleanArchitecture.Domain.OptionsConfig;
using CleanArchitecture.Infraestructure.DataDapper;
using CleanArchitecture.Infraestructure.DataEjemplo;
using CleanArchitecture.Infraestructure.DataEntityFramework.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infraestructure.DatabaseConfig;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration, InfraestructureConfiguration config)
    {
        if (config.UseEntityFramework.HasValue && config.UseEntityFramework.Value)
        {
            // Add EntityFramework
            services.AddEntityFrameworkRepositories(configuration);
        }
        else
        {
            // Agregar Dapper
            services.AddDapperRepositories(configuration.GetConnectionString(nameof(EjemploContext)));
        }


        return services;
    }
}
