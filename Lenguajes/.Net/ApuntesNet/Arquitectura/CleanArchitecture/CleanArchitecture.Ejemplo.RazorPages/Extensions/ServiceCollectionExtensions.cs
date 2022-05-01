using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.ApplicationCore.NegocioEjemplo;
using CleanArchitecture.Domain.OptionsConfig;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using CleanArchitecture.Infraestructure.DataDapper.Contexts;
using CleanArchitecture.Infraestructure.DataDapper.Repositories;
using CleanArchitecture.Infraestructure.DataEjemplo;
using CleanArchitecture.Infraestructure.DataEntityFramework.Contexts;
using CleanArchitecture.Infraestructure.DataEntityFramework.Entities;
using CleanArchitecture.Infraestructure.DataEntityFramework.Repositories;
using CleanArchitecture.Infraestructure.DataEntityFramework.Repositories.IdentityFramework;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CleanArchitecture.Ejemplo.RazorPages.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        services.AddAutoMapper(typeof(Program), typeof(EjemploContext), typeof(EjemploDapperDatabase));
        services.AddOptions();
        services.Configure<InfraestructureConfiguration>(configuration);
        var config = services.BuildServiceProvider().GetRequiredService<IOptions<InfraestructureConfiguration>>().Value;

        services.AddCapaNegocio();
        services.AddDatabaseConfig(configuration, config);

        if (config.UseIdentity.HasValue && config.UseIdentity.Value)
        {
            services.AddIdentityFramework(configuration);
        }
        else
        {
            services.AddIdentityAuthorization(config);
        }

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

    internal static IServiceCollection AddIdentityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequiredLength = 8;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;

        }).AddSignInManager<SignInManager<User>>()
        .AddRoles<Role>()
        .AddEntityFrameworkStores<EjemploContext>();

        if (!services.Any(x => x.ServiceType == typeof(EjemploContext)))
        {
            services.AddContextDatabase<EjemploContext>(configuration);
        }

        services.AddScoped<IIdentityUser, IdentityFrameworkRepository>();

        return services;
    }

    internal static IServiceCollection AddIdentityAuthorization(this IServiceCollection services, InfraestructureConfiguration infraConfig)
    {
        services.AddAuthentication("Cookies").AddCookie(option =>
        {
            option.Cookie = new CookieBuilder
            {
                Name = "Authentication",
                HttpOnly = true,
                SecurePolicy = CookieSecurePolicy.Always,
                SameSite = SameSiteMode.Strict,
                IsEssential = true,
                Path = "/"
            };
        });
        services.AddHttpContextAccessor();

        if (infraConfig.UseEntityFramework.HasValue && infraConfig.UseEntityFramework.Value)
        {
            services.AddScoped<IIdentityUser, UserEfRepository>();
        }
        else
        {
            services.AddScoped<IIdentityUser, IdentityUserManagerDapperRepository>();
        }

        return services;
    }
}
