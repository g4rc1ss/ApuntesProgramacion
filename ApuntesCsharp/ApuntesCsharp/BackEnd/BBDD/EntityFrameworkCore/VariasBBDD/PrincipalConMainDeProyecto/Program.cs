namespace PrincipalConMainDeProyecto {
    internal class Program {
        private static void Main(string[] args) {
            EjecutarConsultasSqlServer.EjecutarSentenciasLinqAndSQL();
            EjecutarConsultasSqlite.EjecutarSentenciasLinqAndSQL();
        }
    }
}
