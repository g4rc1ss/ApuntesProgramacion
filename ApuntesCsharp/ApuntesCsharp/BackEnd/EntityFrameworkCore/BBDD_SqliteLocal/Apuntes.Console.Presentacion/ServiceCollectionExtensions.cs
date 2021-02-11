﻿using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Apuntes.Console.Presentacion {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddApuntesConsolePresentacion(this IServiceCollection services) {
            foreach (var managerType in Assembly.GetExecutingAssembly().GetTypes()
                                                                        .Where(x => x.Name.Contains("Console"))) services.AddScoped(managerType);
            return services;
        }
    }
}
