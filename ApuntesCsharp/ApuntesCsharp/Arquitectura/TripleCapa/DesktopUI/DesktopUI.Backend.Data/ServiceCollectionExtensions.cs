using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DesktopUI.Backend.Data {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddBackendData(this IServiceCollection services) {
            var tiposDam = (from type in Assembly.GetExecutingAssembly().GetTypes()
                               where type.Name.Contains("Dam") && type.IsClass
                               select type).ToDictionary(key => key.GetInterfaces().Where(x => x.Name.Contains(key.Name)).First(), value => value);

            foreach (var damType in tiposDam) {
                services.AddScoped(damType.Key, damType.Value);
            }

            return services;
        }
    }
}
