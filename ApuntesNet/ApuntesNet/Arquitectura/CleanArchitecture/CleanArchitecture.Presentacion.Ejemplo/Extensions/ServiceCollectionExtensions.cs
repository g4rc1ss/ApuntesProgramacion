using CleanArchitecture.ApplicationCore.DataEjemplo;
using CleanArchitecture.ApplicationCore.Dominio.EntidadesDatabase.Identity;
using CleanArchitecture.ApplicationCore.NegocioEjemplo;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Presentacion.Ejemplo.Extensions;

internal static class ServiceCollectionExtensions {
    internal static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration configuration) {
        services.AddIdentity<User, UserRole>(options => {
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
