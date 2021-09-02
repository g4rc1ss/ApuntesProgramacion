﻿using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Backend.Data {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddWebApiBackendData(this IServiceCollection services) {
            var tipos = (from type in Assembly.GetExecutingAssembly().GetTypes()
                         where type.Name.Contains("Dam") && type.IsClass
                         select type).ToDictionary(key => key.GetInterfaces().Where(x => x.Name.Contains(key.Name)).First(), value => value);

            foreach (var damType in tipos) {
                services.AddScoped(damType.Key, damType.Value);
            }

            return services;
        }
    }
}