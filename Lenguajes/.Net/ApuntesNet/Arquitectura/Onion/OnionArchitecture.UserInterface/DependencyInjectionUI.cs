using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Domain.Interfaces.UserInterfaceContracts;
using OnionArchitecture.UserInterface.ListaUsuarios;

namespace OnionArchitecture.UserInterface
{
    internal static class DependencyInjectionUI
    {
        internal static IServiceCollection AddUserIntefaces(this IServiceCollection services)
        {
            services.AddTransient<IListaUsuarioUI, ListaUsuariosUI>();

            return services;
        }
    }
}
