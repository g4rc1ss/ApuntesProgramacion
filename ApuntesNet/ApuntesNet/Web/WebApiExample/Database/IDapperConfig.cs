using System.Data;

namespace WebApiExample.Database
{
    public interface IDapperConfig
    {
        IDbConnection GetConnection();
    }
}
