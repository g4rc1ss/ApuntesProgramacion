using CleanArchitecture.ApplicationCore.NegocioEjemplo;
using CleanArchitecture.Domain.OptionsConfig;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using CleanArchitecture.Infraestructure.DataEjemplo;
using Microsoft.AspNetCore.DataProtection;

namespace CleanArchitecture.Ejemplo.RazorPages.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions();
        services.Configure<InfraestructureConfiguration>(configuration);
        services.AddCapaNegocio();
        services.AddDatabaseConfig(configuration);

        return services;
    }

    internal static IServiceCollection AddRedisCache(this IServiceCollection services)
    {
        //services.AddStackExchangeRedisCache(options =>
        //{
        //    options.Configuration = "localhost:6379,password=password123";
        //    options.InstanceName = "localhost";
        //});
        services.AddDistributedMemoryCache();
        return services;
    }

    internal static IServiceCollection ConfigureDataProtectionProvider(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataProtection()
            .AddDataProtectionEntityFramework(configuration)
            .SetApplicationName("Aplicacion.CleanArchitecture");
        return services;
    }
}
