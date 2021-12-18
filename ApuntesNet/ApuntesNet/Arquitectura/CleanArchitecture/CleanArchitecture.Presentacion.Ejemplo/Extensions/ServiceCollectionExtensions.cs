using CleanArchitecture.ApplicationCore.DataEjemplo;
using CleanArchitecture.ApplicationCore.Dominio.EntidadesDatabase.Identity;
using CleanArchitecture.ApplicationCore.NegocioEjemplo;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using CleanArchitecture.Infraestructure.DatabaseConfig.DbConnectionExtension;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

        services.AddDbContextFactory<EjemploContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString(nameof(EjemploContext)));
        });
        services.AddScoped(p => p.BuildServiceProvider().GetRequiredService<IDbContextFactory<EjemploContext>>().CreateDbContext());
        services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>(service => 
            new DbConnectionFactory(() => service.GetRequiredService<EjemploContext>().Database.GetDbConnection()));
        services.AddCapaNegocio();
        services.AddCapaDatos();

        return services;
    }
}
