using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Apuntes.BackLocal.Core {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddApuntesBackLocalCore(this IServiceCollection services) {
            foreach (var managerType in Assembly.GetExecutingAssembly().GetTypes()
                                                                        .Where(x => x.Name.Contains("Manager"))) {
                services.AddScoped(managerType);
            }

            foreach (var managerType in Assembly.GetExecutingAssembly().GetTypes()
                                                                        .Where(x => x.Name.Contains("Action"))) {
                services.AddScoped(managerType);
            }

            return services;
        }
    }
}
