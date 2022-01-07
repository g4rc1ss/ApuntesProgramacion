using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.ApplicationServices.Business.UserManager;
using OnionArchitecture.Domain.Interfaces.BusinessContracts;

namespace OnionArchitecture.ApplicationServices
{
    public static class DependencyInjectionDatabase
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddTransient<IUserManager, UserManager>();

            return services;
        }
    }
}
