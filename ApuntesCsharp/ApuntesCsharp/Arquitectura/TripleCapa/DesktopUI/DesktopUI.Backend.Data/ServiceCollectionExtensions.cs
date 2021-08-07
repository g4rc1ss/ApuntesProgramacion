using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DesktopUI.Backend.Data {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddBackendData(this IServiceCollection services) {
            foreach (var damType in Assembly.GetExecutingAssembly().GetTypes()
                                                                    .Where(x => x.Name.Contains("Dam")).ToList()) {
                _ = services.AddScoped(damType);
            }
            return services;
        }
    }
}
