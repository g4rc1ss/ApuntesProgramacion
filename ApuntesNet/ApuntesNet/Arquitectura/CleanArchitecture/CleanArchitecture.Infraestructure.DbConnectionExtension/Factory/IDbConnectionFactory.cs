using System.Data.Common;

namespace CleanArchitecture.Infraestructure.DbConnectionExtension.Factory;

public interface IDbConnectionFactory
{
    DbConnection CreateDbConnection();
}

public interface IDbConnectionFactory<TDatabaseNameContext> : IDbConnectionFactory
{

}
