using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AutomapperLibrary
{
    public class Helper
    {
        public static IServiceProvider GetServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddMediatR(typeof(Program));

            return services.BuildServiceProvider();
        }
    }
}
