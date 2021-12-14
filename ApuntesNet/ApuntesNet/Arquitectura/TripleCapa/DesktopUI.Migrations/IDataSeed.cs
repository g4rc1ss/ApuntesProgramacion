using System.Threading;
using System.Threading.Tasks;
using DesktopUI.Backend.Data;

namespace DesktopUI.Migrations {
    public interface IDataSeed {
        Task Seed(ContextoSqlServer context, CancellationToken cancellationToken = default);
    }
}
