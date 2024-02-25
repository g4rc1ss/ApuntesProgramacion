using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using SqlServerEfCore.Database;
using SqlServerEfCore.Repository;

namespace SqlServerEfCore;

internal class Helper
{
    public static IServiceProvider CreateDependencyInjection()
    {
        var builder = Host.CreateDefaultBuilder();
        builder.ConfigureAppConfiguration(config =>
        {

        });

        builder.ConfigureServices((hostContext, services) =>
        {
            services.AddDbContextPool<EntityFrameworkSqlServerContext>(dbContextBuilder => dbContextBuilder.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(EntityFrameworkSqlServerContext))));

            services.AddTransient<SelectData>();
            services.AddTransient<InsertData>();
            services.AddTransient<UpdateData>();
            services.AddTransient<DeleteData>();
        });

        return builder.Build().Services;
    }

}
