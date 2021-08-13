public class UsoSqlite {
    public static void main(String[] args) {
        new SQLite.createTable().crearTable();
        new SQLite.InsertInto().insertDatos();
        new SQLite.Select().consultarDatos();
        new SQLite.Update().actualizarDatos();
        new SQLite.Delete().borrarDatos();
    }
}
