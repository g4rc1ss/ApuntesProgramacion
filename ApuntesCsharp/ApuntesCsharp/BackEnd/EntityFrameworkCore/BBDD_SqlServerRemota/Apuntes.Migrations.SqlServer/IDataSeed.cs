using Apuntes.Back.Core.Database;
using System.Threading;
using System.Threading.Tasks;

namespace Apuntes.Migrations.SqlServer {
    public interface IDataSeed {
        Task Seed(ContextoMSSQL context, CancellationToken cancellationToken = default);
    }
}
