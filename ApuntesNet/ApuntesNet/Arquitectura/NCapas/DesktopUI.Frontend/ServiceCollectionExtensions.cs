using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DesktopUI.Frontend
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFrontend(this IServiceCollection services)
        {
            foreach (var managerType in Assembly.GetExecutingAssembly().GetTypes()
                                                                        .Where(x => x.Name.Contains("Window")))
            {
                _ = services.AddScoped(managerType);
            }

            return services;
        }
    }
}
