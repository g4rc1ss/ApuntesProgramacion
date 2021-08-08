﻿using DataAccessLayer.DataAccessManager;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace InmobiliariaEguzkimendi.DataAccessLayer {
    public static class ServiceCollectionExtensions {
        public static IServiceCollection AddEguzkimendiDAL(this IServiceCollection services) {
            foreach (var damType in Assembly.GetExecutingAssembly().GetTypes()
                                                                    .Where(x => x.Namespace == typeof(UserDam).Namespace).ToList()) {
                services.AddScoped(damType);
            }
            return services;
        }
    }
}