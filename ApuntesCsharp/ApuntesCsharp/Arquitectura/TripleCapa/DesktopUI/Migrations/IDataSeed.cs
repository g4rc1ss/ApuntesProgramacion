using System.Threading;
using System.Threading.Tasks;
using Backend.Data;

namespace Migrations {
    public interface IDataSeed {
        Task Seed(ContextoSqlite context, CancellationToken cancellationToken = default);
    }
}
