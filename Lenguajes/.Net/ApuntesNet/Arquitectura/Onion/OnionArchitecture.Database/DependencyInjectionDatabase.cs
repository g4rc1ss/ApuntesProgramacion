using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Database.UserDb;
using OnionArchitecture.Domain.Interfaces.DatabaseContracts.UserContracts;

namespace OnionArchitecture.Database
{
    public static class DependencyInjectionDatabase
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddTransient<IClaseSimuloBaseDeDatos, ClaseSimuloBaseDeDatos>();

            return services;
        }
    }
}
