using System.Data;

namespace WebApiExample.Databsae {
    public interface IDapperConfig {
        IDbConnection GetConnection();
    }
}