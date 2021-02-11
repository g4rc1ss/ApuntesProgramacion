package ORMHibernate._02_BackendBusinessLogic.BusinessManager;

import ORMHibernate._03_Database.Dam.DirectorDam;
import ORMHibernate._03_Database.Entities.Director;

import java.util.List;

public class DirectorBusiness {
    public DirectorBusiness() {

    }

    public List<Director> getAllDirector() {
        return new DirectorDam().getAllDirector();
    }

    public List getDirectorById(int id) {
        return new DirectorDam().getDirectorById(id);
    }

    public List<Director> getDirectoresWithOrder() {
        return new DirectorDam().getAllDirectorOrderBy();
    }

    public List<Director> getDirectorWithGroupBy() {
        return new DirectorDam().getAllDirectorGroupByName();
    }

    public void setNewDirector() {
        var director = new Director();
        new DirectorDam().setNewDirector(director);
    }

    public int updateDirector(int id) {
        var directorDam = new DirectorDam();
        var directorToUpdate = directorDam.getDirectorById(id);
        var director = directorToUpdate.get(0);
        director.setId(id);
        var count = directorDam.updateDirector(director);
        return count;
    }

    public int deleteDirector(int id) {
        return new DirectorDam().deleteDirector(id);
    }
}
