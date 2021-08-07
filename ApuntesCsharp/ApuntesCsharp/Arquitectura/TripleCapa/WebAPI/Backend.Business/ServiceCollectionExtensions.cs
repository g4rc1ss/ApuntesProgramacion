using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace InmobiliariaEguzkimendi.DataAccessLayer {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddEguzkimendiCore(this IServiceCollection services) {
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
