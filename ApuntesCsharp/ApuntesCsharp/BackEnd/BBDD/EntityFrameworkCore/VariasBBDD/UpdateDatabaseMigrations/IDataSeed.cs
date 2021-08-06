using System.Threading;
using System.Threading.Tasks;
using Apuntes.Back.Core.Database;

namespace Apuntes.Migrations.SqlServer {
    public interface IDataSeed {
        Task Seed(ContextoSqlite context, CancellationToken cancellationToken = default);
        Task Seed(ContextoMSSQL context, CancellationToken cancellationToken = default);
    }
}
