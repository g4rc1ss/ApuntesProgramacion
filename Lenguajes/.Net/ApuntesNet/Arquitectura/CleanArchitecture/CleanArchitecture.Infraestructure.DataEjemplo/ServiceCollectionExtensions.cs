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
        services.AddDbContextFactory<EjemploContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(nameof(EjemploContext)));
        });
        services.AddEntityFrameworkServices();

        return services;
    }

    public static IServiceCollection AddIdentityEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;

        }).AddSignInManager<SignInManager<User>>()
        .AddRoles<Role>()
        .AddEntityFrameworkStores<EjemploContext>();
        services.AddDbContext<EjemploContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(nameof(EjemploContext)));
        });
        services.AddScoped<IIdentityUserRepository, IdentityUserRepository>();

        return services;
    }

    public static IDataProtectionBuilder AddDataProtectionEntityFramework(this IDataProtectionBuilder dataProtection, IConfiguration configuration)
    {
        dataProtection.Services.AddDbContextPool<KeyDataProtectorContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString(nameof(KeyDataProtectorContext)));
        });
        dataProtection.PersistKeysToDbContext<KeyDataProtectorContext>();

        return dataProtection;
    }

    private static IServiceCollection AddEntityFrameworkServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
