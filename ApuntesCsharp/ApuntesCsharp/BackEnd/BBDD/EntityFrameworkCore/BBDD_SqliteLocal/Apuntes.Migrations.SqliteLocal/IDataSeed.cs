using Apuntes.BackLocal.DataAccessLayer.Database;
using System.Threading;
using System.Threading.Tasks;

namespace Apuntes.Migrations.SqliteLocal {
    public interface IDataSeed {
        Task Seed(ContextoSqlite context, CancellationToken cancellationToken = default);
    }
}
