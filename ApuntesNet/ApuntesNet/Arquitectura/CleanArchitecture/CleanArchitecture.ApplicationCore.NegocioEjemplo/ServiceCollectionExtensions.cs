using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.ApplicationCore.NegocioEjemplo;

public static class ServiceCollectionExtensions {
    public static IServiceCollection AddNegocio(this IServiceCollection services) {

        var tipos = (from type in Assembly.GetExecutingAssembly().GetTypes()
                     where type.Name.Contains("Negocio") && type.IsClass
                     select type).ToDictionary(key => key.GetInterfaces().Where(x => x.Name.Contains(key.Name)).First(), value => value);

        foreach (var damType in tipos) {
            services.AddScoped(damType.Key, damType.Value);
        }

        return services;
    }
}
