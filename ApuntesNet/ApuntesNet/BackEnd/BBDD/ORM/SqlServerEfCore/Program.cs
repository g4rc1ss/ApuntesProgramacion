using SqlServerEfCore.Core;
using SqlServerEfCore.Database;

namespace SqlServerEfCore {
    internal class Program {
        private static void Main() {
            try {
                using (var context = new ContextoMSSQL()) {
                    context.CreateDatabase();
                }

                EjecutarConsultasSqlServer.EjecutarSentenciasLinqAndSQL();

            } finally {
                using (var context = new ContextoMSSQL()) {
                    context.DeleteDatabase();
                }
            }
        }
    }
}
