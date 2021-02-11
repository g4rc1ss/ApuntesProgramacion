using DataAccessLayer;
using System.Threading;
using System.Threading.Tasks;

namespace Migrations {
    public interface IDataSeed {
        Task Seed(WebApiPruebaContext context, CancellationToken cancellationToken = default);
    }
}
