using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Infraestructure.DatabaseConfig;

namespace CleanArchitecture.Infraestructure.InitDatabase;

// Clase que invoka a una interfaz, que esta esta vinculada a un Seed.
// Con esta clase nos encargamos de inicializar la BBDD siempre con los datos que queramos
public class DatabaseInitializer {
    private readonly IEnumerable<IDataSeed> dataSeeds;
    private readonly EjemploContext webApiPruebaContext;

    public DatabaseInitializer(
        IEnumerable<IDataSeed> dataSeeds, EjemploContext webApiPruebaContext) {
        this.dataSeeds = dataSeeds;
        this.webApiPruebaContext = webApiPruebaContext;
    }

    public async Task Initialize(CancellationToken cancellationToken = default) {
        foreach (var seed in dataSeeds) {
            await seed.Seed(webApiPruebaContext, cancellationToken);
        }
    }
}
