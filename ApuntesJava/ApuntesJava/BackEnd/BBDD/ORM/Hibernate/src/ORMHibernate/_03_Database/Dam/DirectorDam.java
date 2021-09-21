package ORMHibernate._03_Database.Dam;

import ORMHibernate._03_Database.Dam.Base.DataAccessManager;
import ORMHibernate._03_Database.Entities.Director;

import java.util.List;

public class DirectorDam extends DataAccessManager {
    public DirectorDam() {
        super();
    }

    public List<Director> getAllDirector() {
        try (var context = super.getContextFactory()) {
            return (List<Director>) context.createQuery("From Director").getResultList();
        }
    }

    public List<Director> getDirectorById(int id) {
        try (var context = super.getContextFactory()) {
            var query = context.createQuery("From Director D Where D.id = :directorId");
            query.setParameter("directorId", id);
            return (List<Director>) query.getResultList();
        }
    }

    public List getAllDirectorOrderBy() {
        try (var context = super.getContextFactory()) {
            return (List<Director>) context.createQuery(
                    "From Director D " +
                            "ORDER BY D.id DESC").getResultList();
        }
    }

    public List getAllDirectorGroupByName() {
        try (var context = super.getContextFactory()) {
            return (List<Director>) context.createQuery(
                    "From Director D " +
                            "GROUP BY D.nombre").getResultList();
        }
    }

    public void setNewDirector(Director director) {
        try (var context = super.getContextFactory()) {
            var transaccion = context.beginTransaction();
            context.save(director);
            transaccion.commit();
        }
    }

    public int updateDirector(Director director) {
        try (var context = super.getContextFactory()) {
            var transaccion = context.beginTransaction();
            var query = context.createQuery(
                    "UPDATE Director D set nombre = :nombre, apellidos = :apellidos " +
                            "WHERE id = :directorId");
            query.setParameter("nombre", director.getNombre());
            query.setParameter("apellidos", director.getApellidos());
            query.setParameter("directorId", director.getId());
            var count = query.executeUpdate();
            transaccion.commit();
            return count;
        }
    }

    public int deleteDirector(int id) {
        try (var context = super.getContextFactory()) {
            var transaccion = context.beginTransaction();
            var query = context.createQuery(
                    "DELETE FROM Director D " +
                            "WHERE D.id = :directorId");
            query.setParameter("directorId", id);
            var count = query.executeUpdate();
            transaccion.commit();
            return count;
        }
    }
}
