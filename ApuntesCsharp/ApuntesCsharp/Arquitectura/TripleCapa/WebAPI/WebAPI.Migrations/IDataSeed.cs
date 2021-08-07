using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer;

namespace WebAPI.Migrations {
    public interface IDataSeed {
        Task Seed(WebApiPruebaContext context, CancellationToken cancellationToken = default);
    }
}
