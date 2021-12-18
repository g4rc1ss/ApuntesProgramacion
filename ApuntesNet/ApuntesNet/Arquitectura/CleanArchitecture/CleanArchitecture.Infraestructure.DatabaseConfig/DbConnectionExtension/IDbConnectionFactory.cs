using System.Data.Common;

namespace CleanArchitecture.Infraestructure.DatabaseConfig.DbConnectionExtension;

public interface IDbConnectionFactory {
    DbConnection CreateDbConnection();
}
