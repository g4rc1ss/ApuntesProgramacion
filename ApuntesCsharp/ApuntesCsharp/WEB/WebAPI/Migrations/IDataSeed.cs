using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Migrations {
    public interface IDataSeed {
        Task Seed(WebApiPruebaContext context, CancellationToken cancellationToken = default);
    }
}
