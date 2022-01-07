using CleanArchitecture.ApplicationCore.Domain.Database.Entities.Identity;
using CleanArchitecture.ApplicationCore.NegocioEjemplo;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using CleanArchitecture.Infraestructure.DatabaseConfig.Identity;
using CleanArchitecture.Infraestructure.DataEjemplo;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Ejemplo.Extensions;

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
}
