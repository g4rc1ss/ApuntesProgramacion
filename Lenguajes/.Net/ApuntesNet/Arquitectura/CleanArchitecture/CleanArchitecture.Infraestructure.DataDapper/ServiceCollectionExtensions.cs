using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Infraestructure.DataDapper.Contexts;
using CleanArchitecture.Infraestructure.DataDapper.Repositories;
using CleanArchitecture.Infraestructure.DbConnectionExtension.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infraestructure.DataDapper;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDapperRepositories(this IServiceCollection services, string connectionString)
    {
        services.AddAutoMapper(typeof(EjemploDapperDatabase));
        services.AddDbConnectionFactory<EjemploDapperDatabase>(() => new SqlConnection(connectionString));


        services.AddDapperServices();

        return services;
    }

    public static IServiceCollection AddDapperIdentity(this IServiceCollection services)
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

        services.AddScoped<IIdentityUser, IdentityUserManagerDapperRepository>();

        return services;
    }

    private static IServiceCollection AddDapperServices(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserDetailRepository, UserDetailRepository>();

        return services;
    }
}
