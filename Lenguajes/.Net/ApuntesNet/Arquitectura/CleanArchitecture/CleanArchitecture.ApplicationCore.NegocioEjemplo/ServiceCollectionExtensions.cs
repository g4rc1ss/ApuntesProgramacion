using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.ApplicationCore.NegocioEjemplo.Negocio.UsersManager;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.ApplicationCore.NegocioEjemplo;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCapaNegocio(this IServiceCollection services)
    {
        services.AddScoped<IUserNegocio, UserNegocio>();
        services.AddScoped<IUserDetailNegocio, UserDetailNegocio>();

        return services;
    }
}
