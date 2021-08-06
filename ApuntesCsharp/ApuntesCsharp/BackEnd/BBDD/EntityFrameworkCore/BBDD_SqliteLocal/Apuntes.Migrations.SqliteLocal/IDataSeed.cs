using System.Threading;
using System.Threading.Tasks;
using Apuntes.BackLocal.DataAccessLayer.Database;

namespace Apuntes.Migrations.SqliteLocal {
    public interface IDataSeed {
        Task Seed(ContextoSqlite context, CancellationToken cancellationToken = default);
    }
}
