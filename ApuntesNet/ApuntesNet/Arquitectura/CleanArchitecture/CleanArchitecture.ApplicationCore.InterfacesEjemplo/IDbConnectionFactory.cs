using System.Data.Common;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo;

public interface IDbConnectionFactory
{
    DbConnection CreateDbConnection();
}

public interface IDbConnectionFactory<TDatabaseNameContext> : IDbConnectionFactory
{

}
