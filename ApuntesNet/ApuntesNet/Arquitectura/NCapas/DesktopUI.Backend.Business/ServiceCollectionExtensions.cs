using DesktopUI.Backend.Business.Actions;
using DesktopUI.Backend.Business.Actions.Interfaces;
using DesktopUI.Backend.Business.Manager;
using DesktopUI.Backend.Business.Manager.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DesktopUI.Backend.Business
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBackendBusiness(this IServiceCollection services)
        {
            // Actions
            services.AddTransient<IUserAction, UserAction>();

            // Managers
            services.AddTransient<IUserManager, UserManager>();

            return services;
        }
    }
}
