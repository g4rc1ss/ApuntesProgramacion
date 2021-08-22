import java.sql.SQLException;

public class UsoMariaDB {
    public static void main(String[] args) throws SQLException, ClassNotFoundException {
        new MariaDB.CreateTable().createTableExecute();
        new MariaDB.Insert().InsertExecute();
        new MariaDB.Select().SelecExecute();
        new MariaDB.Update().updateExecute();
        new MariaDB.Delete().deleteExecute();
    }
}
