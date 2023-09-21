using System.Data.Common;

namespace Garciss.DbConnectionExtensions.Factory;

public interface IDbConnectionFactory
{
    DbConnection CreateDbConnection();
}

public interface IDbConnectionFactory<TDatabaseNameContext> : IDbConnectionFactory
{

}
