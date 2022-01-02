using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ConversorArchivos
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInyection(this IServiceCollection services)
        {
            var tiposWindow = (from type in Assembly.GetExecutingAssembly().GetTypes()
                               where type.Name.Contains("Window") && type.IsClass
                               select type).ToList();

            var tiposAction = (from type in Assembly.GetExecutingAssembly().GetTypes()
                               where type.Name.Contains("Action") && type.IsClass
                               select type).ToDictionary(key => key.GetInterfaces().Where(x => x.Name.Contains(key.Name)).First(), value => value);

            var tiposManager = (from type in Assembly.GetExecutingAssembly().GetTypes()
                                where type.Name.Contains("Manager") && type.IsClass
                                select type).ToDictionary(key => key.GetInterfaces().Where(x => x.Name.Contains(key.Name)).First(), value => value);

            foreach (var damType in tiposWindow)
            {
                _ = services.AddScoped(damType);
            }

            foreach (var damType in tiposAction)
            {
                _ = services.AddScoped(damType.Key, damType.Value);
            }

            foreach (var damType in tiposManager)
            {
                _ = services.AddScoped(damType.Key, damType.Value);
            }

            return services;
        }
    }
}
