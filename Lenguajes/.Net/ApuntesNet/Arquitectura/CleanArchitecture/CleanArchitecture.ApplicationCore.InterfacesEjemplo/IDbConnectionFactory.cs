using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Database.ModelEntity;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo;

public interface IDbConnectionFactory
{
    DbConnection CreateDbConnection();
}

public interface IDbConnectionFactory<TDatabaseNameContext> : IDbConnectionFactory
{
}
