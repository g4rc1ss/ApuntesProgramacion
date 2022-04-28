using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Infraestructure.DataEjemplo.DataAccessManager;
using CleanArchitecture.Infraestructure.DataEntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infraestructure.DataEjemplo;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services, IConfiguration configuration)
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
        services.AddEntityFrameworkServices();

        return services;
    }

    private static IServiceCollection AddEntityFrameworkServices(this IServiceCollection services)
    {
        services.AddScoped<IUserDam, UserDam>();

        return services;
    }
}
