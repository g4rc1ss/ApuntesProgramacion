using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Infraestructure.DataEjemplo.DataAccessManager;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infraestructure.DataEjemplo;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserDam, UserDam>();

        return services;
    }
}
