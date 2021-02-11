namespace BasesDeDatos {
    internal class UsoBaseDatos {
        private static void Main(string[] args) {
            new SQLite.UsarBBDD_SQLite().UsarSQLite();
            new MySQL.UsarBBDD_MySQL().BaseMySQL();
        }
    }
}
