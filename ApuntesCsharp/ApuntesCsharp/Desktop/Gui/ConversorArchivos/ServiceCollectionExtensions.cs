using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace ConversorArchivos
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyInyection(this IServiceCollection services)
        {
            System.Collections.Generic.List<Type> tiposWindow = (from type in Assembly.GetExecutingAssembly().GetTypes()
                                                                 where type.Name.Contains("Window") && type.IsClass
                                                                 select type).ToList();

            System.Collections.Generic.Dictionary<Type, Type> tiposAction = (from type in Assembly.GetExecutingAssembly().GetTypes()
                                                                             where type.Name.Contains("Action") && type.IsClass
                                                                             select type).ToDictionary(key => key.GetInterfaces().Where(x => x.Name.Contains(key.Name)).First(), value => value);

            System.Collections.Generic.Dictionary<Type, Type> tiposManager = (from type in Assembly.GetExecutingAssembly().GetTypes()
                                                                              where type.Name.Contains("Manager") && type.IsClass
                                                                              select type).ToDictionary(key => key.GetInterfaces().Where(x => x.Name.Contains(key.Name)).First(), value => value);

            foreach (Type damType in tiposWindow)
            {
                _ = services.AddScoped(damType);
            }

            foreach (System.Collections.Generic.KeyValuePair<Type, Type> damType in tiposAction)
            {
                _ = services.AddScoped(damType.Key, damType.Value);
            }

            foreach (System.Collections.Generic.KeyValuePair<Type, Type> damType in tiposManager)
            {
                _ = services.AddScoped(damType.Key, damType.Value);
            }

            return services;
        }
    }
}
