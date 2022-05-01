using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Infraestructure.DataEjemplo.DataAccessManager;
using CleanArchitecture.Infraestructure.DataEntityFramework.Contexts;
using CleanArchitecture.Infraestructure.DataEntityFramework.Entities;
using CleanArchitecture.Infraestructure.DataEntityFramework.Repositories;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infraestructure.DataEjemplo;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddContextDatabase<EjemploContext>(configuration);
        services.AddEntityFrameworkServices();

        return services;
    }

    public static IDataProtectionBuilder AddDataProtectionEntityFramework(this IDataProtectionBuilder dataProtection, IConfiguration configuration)
    {
        dataProtection.Services.AddContextDatabase<KeyDataProtectorContext>(configuration);
        dataProtection.PersistKeysToDbContext<KeyDataProtectorContext>();

        return dataProtection;
    }

    public static IServiceCollection AddContextDatabase<TContext>(this IServiceCollection services, IConfiguration configuration) 
        where TContext : DbContext
    {
        services.AddPooledDbContextFactory<TContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(typeof(TContext).Name));
        });

        services.AddDbContextPool<TContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(typeof(TContext).Name));
        });

        return services;
    }

    private static IServiceCollection AddEntityFrameworkServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserDetailRepository, UserDetailRepository>();

        return services;
    }
}
