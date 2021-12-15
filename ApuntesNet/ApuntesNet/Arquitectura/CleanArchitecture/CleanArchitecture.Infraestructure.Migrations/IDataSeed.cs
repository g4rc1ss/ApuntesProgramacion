using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Infraestructure.DatabaseConfig;

namespace WebAPI.Migrations {
    public interface IDataSeed {
        Task Seed(WebApiPruebaContext context, CancellationToken cancellationToken = default);
    }
}
