using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Infraestructure.DataDapper.Contexts;
using CleanArchitecture.Infraestructure.DataDapper.Repositories;
using CleanArchitecture.Infraestructure.DbConnectionExtension.DependencyInjection;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infraestructure.DataDapper;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDapperRepositories(this IServiceCollection services, string connectionString)
    {
        services.AddDbConnectionFactory<EjemploDapperDatabase>(() => new SqlConnection(connectionString));


        services.AddDapperServices();

        return services;
    }

    private static IServiceCollection AddDapperServices(this IServiceCollection services)
    {
        services.AddScoped<IUserDetailRepository, UserDetailRepository>();

        return services;
    }
}
