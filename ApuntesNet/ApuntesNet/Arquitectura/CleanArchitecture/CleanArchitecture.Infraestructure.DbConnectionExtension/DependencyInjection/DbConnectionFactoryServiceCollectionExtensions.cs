using System;
using System.Data.Common;
using CleanArchitecture.Infraestructure.DbConnectionExtension.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Infraestructure.DbConnectionExtension.DependencyInjection;

public static class DbConnectionFactoryServiceCollectionExtensions
{

    public static IServiceCollection AddDbConnectionFactory(this IServiceCollection services, Func<DbConnection> connection)
    {
        services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>(serviceProvider =>
        {
            return new DbConnectionFactory(connection);
        });

        return services;
    }

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
