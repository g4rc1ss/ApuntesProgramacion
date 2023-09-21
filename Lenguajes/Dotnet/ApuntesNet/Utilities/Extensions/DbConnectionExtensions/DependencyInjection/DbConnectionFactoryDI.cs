using System.Data.Common;
using Garciss.DbConnectionExtensions.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Garciss.DbConnectionExtensions.DependencyInjection;

/// <summary>
/// 
/// </summary>
public static class DbConnectionFactoryDI
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connection"></param>
    /// <returns></returns>
    public static IServiceCollection AddDbConnectionFactory(this IServiceCollection services, Func<DbConnection> connection)
    {
        services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>(serviceProvider =>
        {
            return new DbConnectionFactory(connection);
        });

        return services;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TDatabaseNameContext"></typeparam>
    /// <param name="services"></param>
    /// <param name="connection"></param>
    /// <returns></returns>
    public static IServiceCollection AddDbConnectionFactory<TDatabaseNameContext>(this IServiceCollection services, Func<DbConnection> connection)
        where TDatabaseNameContext : class
    {
        services.AddSingleton<IDbConnectionFactory<TDatabaseNameContext>, DbConnectionFactory<TDatabaseNameContext>>(serviceProvider =>
        {
            return new DbConnectionFactory<TDatabaseNameContext>(connection);
        });

        return services;
    }
}
