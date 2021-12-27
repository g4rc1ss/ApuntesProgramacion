using CleanArchitecture.Dominio;

namespace CleanArchitecture.Infraestructure.InitDatabase;

public interface IDataSeed
{
    Task Seed(EjemploContext context, CancellationToken cancellationToken = default);
}
