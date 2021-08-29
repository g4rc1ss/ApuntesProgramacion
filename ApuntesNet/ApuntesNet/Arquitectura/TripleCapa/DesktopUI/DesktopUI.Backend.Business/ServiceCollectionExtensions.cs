using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DesktopUI.Backend.Business {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddBackendBusiness(this IServiceCollection services) {
            var tiposAction = (from type in Assembly.GetExecutingAssembly().GetTypes()
                               where type.Name.Contains("Action") && type.IsClass
                               select type).ToDictionary(key => key.GetInterfaces().Where(x => x.Name.Contains(key.Name)).First(), value => value);

            var tiposManager = (from type in Assembly.GetExecutingAssembly().GetTypes()
                                where type.Name.Contains("Manager") && type.IsClass
                                select type).ToDictionary(key => key.GetInterfaces().Where(x => x.Name.Contains(key.Name)).First(), value => value);

            foreach (var damType in tiposAction) {
                services.AddScoped(damType.Key, damType.Value);
            }

            foreach (var damType in tiposManager) {
                services.AddScoped(damType.Key, damType.Value);
            }

            return services;
        }
    }
}
