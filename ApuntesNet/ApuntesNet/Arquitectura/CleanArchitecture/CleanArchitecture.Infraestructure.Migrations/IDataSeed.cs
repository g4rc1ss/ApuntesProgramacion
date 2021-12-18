using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Infraestructure.DatabaseConfig;

namespace CleanArchitecture.Infraestructure.Migrations;

public interface IDataSeed {
    Task Seed(EjemploContext context, CancellationToken cancellationToken = default);
}
