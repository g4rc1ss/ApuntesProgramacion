using Apuntes.Back.Core.Database;
using Apuntes.Back.Core.SQLite.ModelosBBDD;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Apuntes.Migrations.SqlServer.Seeds {
    public class SeedGenerator :IDataSeed {
        private ContextoSqlite contextoSqlite;
        private ContextoMSSQL contextoMSSQL;

        // Datos a rellenar en el contexto de Sqlite
        public async Task Seed(ContextoSqlite context, CancellationToken cancellationToken = default) {
            await InicializarDatosSqlite();
        }
        // Datos a rellenar en el contexto de MySql
        public async Task Seed(ContextoMSSQL context, CancellationToken cancellationToken = default) {
            await InicializarDatosMSSQL();
        }

        private async Task InicializarDatosSqlite() {
            using (contextoSqlite = new ContextoSqlite()) {
                contextoSqlite.Add(new ModelosParaBBDD() {
                    Nombre = "Nombre",
                    Apellido = "Apellido",
                    Direccion = "C/ Direccion",
                    Edad = 22,
                    Material = new List<ModeloDosConClaveForanea>() { new ModeloDosConClaveForanea() {
                        Material = "Materiall",
                        TipoMaterial = TipoMaterial.Avion,
                    }}
                });
                await contextoSqlite.SaveChangesAsync();
            }
        }

        private async Task InicializarDatosMSSQL() {
            using (contextoMSSQL = new ContextoMSSQL()) {
                contextoMSSQL.Add(new ModelosParaBBDD() {
                    Nombre = "Nombre",
                    Apellido = "Apellido",
                    Direccion = "C/ Direccion",
                    Edad = 22,
                    Material = new List<ModeloDosConClaveForanea>() { new ModeloDosConClaveForanea() {
                        Material = "Materiall",
                        TipoMaterial = TipoMaterial.Avion,
                    }}
                });
                await contextoMSSQL.SaveChangesAsync();
            }
        }
    }
}
