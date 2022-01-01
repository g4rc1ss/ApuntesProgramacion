using Microsoft.Extensions.DependencyInjection;

namespace DesktopUI.Frontend
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFrontend(this IServiceCollection services)
        {
            services.AddTransient<MainWindow>();

            return services;
        }
    }
}
