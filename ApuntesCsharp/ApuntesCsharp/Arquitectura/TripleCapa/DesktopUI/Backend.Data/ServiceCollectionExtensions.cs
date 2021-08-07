using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Data {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddApuntesDataAccessLayer(this IServiceCollection services) {
            foreach (var damType in Assembly.GetExecutingAssembly().GetTypes()
                                                                    .Where(x => x.Name.Contains("Dam")).ToList()) {
                services.AddScoped(damType);
            }
            return services;
        }
    }
}
