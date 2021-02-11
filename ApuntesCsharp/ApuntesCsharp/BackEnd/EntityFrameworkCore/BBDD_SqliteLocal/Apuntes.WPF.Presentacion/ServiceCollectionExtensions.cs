using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Apuntes.WPF.Presentacion {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddApuntesConsolePresentacion(this IServiceCollection services) {
            foreach (var managerType in Assembly.GetExecutingAssembly().GetTypes()
                                                                        .Where(x => x.Name.Contains("Window"))) services.AddScoped(managerType);
            return services;
        }
    }
}
