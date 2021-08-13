import ORMHibernate.Migrations.SeedPrincipal;
import ORMHibernate._01_FrontendLogic.DirectorConsole;

import java.sql.SQLException;

public class UsoBaseDeDatos {
    public static void main(String[] args) throws SQLException, ClassNotFoundException {
        // SQLite
//        new SQLite.createTable().crearTable();
//        new SQLite.InsertInto().insertDatos();
//        new SQLite.Select().consultarDatos();
//        new SQLite.Update().actualizarDatos();
//        new SQLite.Delete().borrarDatos();

        //Oracle
        /*
        new Oracle.createTable().createTableExecute();
        new Oracle.InsertInto().insertIntoExecute();
        new Oracle.Select().selectExecute();
        new Oracle.Update().updateExecute();
        new Oracle.Delete().deleteExecute();
        */

        // MySQL
        /*
        new MySQL.DatabaseMetadata().databaseMetadataExecute();
        new MySQL.CreateTable().createTableExecute();
        new MySQL.Insert().InsertExecute();
        new MySQL.Select().SelecExecute();
        new MySQL.Update().updateExecute();
        new MySQL.Delete().deleteExecute();
        */

        //Hibernate
        var seed = new SeedPrincipal();
        if (!seed.isCreateDatabaseWithContent())
            seed.initializeData();
        new DirectorConsole().getDirector();
    }
}
