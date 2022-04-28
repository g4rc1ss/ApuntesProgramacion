using CleanArchitecture.Infraestructure.DataEntityFramework.Contexts;

namespace CleanArchitecture.Infraestructure.InitDatabase;

public interface IDataSeed
{
    Task Seed(EjemploContext context, CancellationToken cancellationToken = default);
}
