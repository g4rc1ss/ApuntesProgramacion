using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using PostgresqlDapper.Repository;
using PostgresqlDapper.Repository.SelectDapperMethod;

namespace PostgresqlDapper
{
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
                services.AddTransient<IDbConnection>(x => new NpgsqlConnection(hostContext.Configuration.GetConnectionString("Database")));

                services.AddTransient<CreateTable>();
                services.AddTransient<InsertData>();
                services.AddTransient<DeleteData>();
                services.AddTransient<UpdateData>();
                services.AddTransient<SelectData>();

            });

            return builder.Build().Services;
        }

    }
}
