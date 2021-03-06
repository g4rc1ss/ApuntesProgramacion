﻿using Apuntes.Back.Core.Database;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Apuntes.Migrations.SqlServer {

    // Clase que invoka a una interfaz, que esta esta vinculada a un Seed.
    // Con esta clase nos encargamos de inicializar la BBDD siempre con los datos que queramos
    public class DatabaseInitializer {
        private readonly IEnumerable<IDataSeed> dataSeeds;
        private readonly ContextoMSSQL contextoMSSQL;

        public DatabaseInitializer(
            IEnumerable<IDataSeed> dataSeeds, ContextoMSSQL contextoMSSQL) {
            this.dataSeeds = dataSeeds;
            this.contextoMSSQL = contextoMSSQL;
        }

        public async Task Initialize(CancellationToken cancellationToken = default) {
            foreach (var seed in dataSeeds) {
                await seed.Seed(contextoMSSQL, cancellationToken);
            }
        }
    }
}
