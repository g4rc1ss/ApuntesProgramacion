import ORMHibernate.Migrations.SeedPrincipal;
import ORMHibernate._01_FrontendLogic.DirectorConsole;

import java.sql.SQLException;

public class UsoHibernate {
    public static void main(String[] args) throws SQLException, ClassNotFoundException {
        var seed = new SeedPrincipal();
        if (!seed.isCreateDatabaseWithContent())
            seed.initializeData();
        new DirectorConsole().getDirector();
    }
}
