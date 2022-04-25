using CleanArchitecture.ApplicationCore.NegocioEjemplo;
using CleanArchitecture.Domain.Database.Identity;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using CleanArchitecture.Infraestructure.DataEjemplo;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Ejemplo.API.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;

        }).AddSignInManager<SignInManager<User>>()
        .AddRoles<Role>()
        .AddEntityFrameworkStores<EjemploContext>();

        services.AddDatabaseConfig(configuration);
        services.AddCapaNegocio();
        services.AddCapaDatos();

        return services;
    }

    internal static IServiceCollection AddRedisCache(this IServiceCollection services)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "localhost:6379,password=password123";
            options.InstanceName = "localhost";
        });
        //services.AddDistributedMemoryCache();
        return services;
    }
}
