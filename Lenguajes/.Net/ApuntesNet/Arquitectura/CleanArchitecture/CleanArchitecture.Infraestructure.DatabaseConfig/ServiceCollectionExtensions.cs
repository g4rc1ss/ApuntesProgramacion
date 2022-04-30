using CleanArchitecture.Infraestructure.DataDapper;
using CleanArchitecture.Infraestructure.DataEjemplo;
using CleanArchitecture.Infraestructure.DataEntityFramework.Contexts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infraestructure.DatabaseConfig;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseConfig(this IServiceCollection services, IConfiguration configuration)
    {
        if (bool.TryParse(configuration.GetSection("UseIdentity").Value, out var usarIdentity) && usarIdentity)
        {
            services.AddIdentityEntityFramework(configuration);
        }
        else
        {
            services.AddDapperIdentity();
        }

        if (bool.TryParse(configuration.GetSection("UseEntityFramework").Value, out var usarEntityFramework) && usarEntityFramework)
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
