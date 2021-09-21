package ORMHibernate.Migrations;

import ORMHibernate._03_Database.Dam.Base.DataAccessManager;
import ORMHibernate._03_Database.Entities.Director;

import java.util.ArrayList;

public class SeedPrincipal extends DataAccessManager {
    public SeedPrincipal() {
        super();
    }

    public void initializeData() {
        var lista = new ArrayList<Integer>();
        for (int x = 0; x < 50; x++) {
            lista.add(x + 1);
            var director = new Director("Nombre" + x, "apellido" + x);
            insertDataIntoDirector(director);
        }
    }

    public boolean isCreateDatabaseWithContent() {
        try (var context = super.getContextFactory()) {
            var query = (ArrayList<Long>) context.createQuery("SELECT Count(id) From Director").getResultList();
            var count = query.get(0).longValue();
            return count > 0;
        }
    }

    private void insertDataIntoDirector(Director director) {
        try (var context = super.getContextFactory()) {
            var transaccion = context.beginTransaction();
            context.save(director);
            transaccion.commit();
        }
    }
}
