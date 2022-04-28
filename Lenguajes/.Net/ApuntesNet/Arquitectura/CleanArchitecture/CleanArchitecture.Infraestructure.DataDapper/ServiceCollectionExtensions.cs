using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Infraestructure.DataDapper.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infraestructure.DataDapper;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDapperRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserDetailDam, UserDetailDam>();

        return services;
    }
}
