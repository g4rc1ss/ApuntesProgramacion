﻿using DesktopUI.Backend.Data;

namespace DesktopUI.Migrations
{

    // Clase que invoka a una interfaz, que esta esta vinculada a un Seed.
    // Con esta clase nos encargamos de inicializar la BBDD siempre con los datos que queramos
    public class DatabaseInitializer
    {
        private readonly IEnumerable<IDataSeed> dataSeeds;
        private readonly ContextoSqlServer contexto;

        public DatabaseInitializer(IEnumerable<IDataSeed> dataSeeds, ContextoSqlServer contexto)
        {
            this.dataSeeds = dataSeeds;
            this.contexto = contexto;
        }

        public async Task Initialize(CancellationToken cancellationToken = default)
        {
            foreach (var seed in dataSeeds)
            {
                await seed.Seed(contexto, cancellationToken);
            }
        }
    }
}