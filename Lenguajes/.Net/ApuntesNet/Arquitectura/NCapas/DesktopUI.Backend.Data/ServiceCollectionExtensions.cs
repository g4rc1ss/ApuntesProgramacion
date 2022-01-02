using DesktopUI.Backend.Data.DataAccessManager;
using DesktopUI.Backend.Data.DataAccessManager.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DesktopUI.Backend.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBackendData(this IServiceCollection services)
        {
            services.AddTransient<IUserDam, UserDam>();

            return services;
        }
    }
}
