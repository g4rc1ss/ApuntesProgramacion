using System.Data;
using System.Data.Common;

namespace CleanArchitecture.Infraestructure.DatabaseConfig.DbConnectionExtension;

public class DbConnectionFactory : IDbConnectionFactory {
    private readonly Func<DbConnection> _connection;

    public DbConnectionFactory(Func<DbConnection> connection) {
        _connection = connection;
    }

    public DbConnection CreateDbConnection() {
        return _connection();
    }
}
