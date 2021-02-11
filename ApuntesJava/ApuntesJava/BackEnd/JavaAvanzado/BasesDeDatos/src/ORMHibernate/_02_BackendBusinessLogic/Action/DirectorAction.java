package ORMHibernate._02_BackendBusinessLogic.Action;

import ORMHibernate._02_BackendBusinessLogic.BusinessManager.DirectorBusiness;

import java.util.List;

public class DirectorAction {
    public DirectorAction() {
    }

    public List getAllDirector() {
        try {
            return new DirectorBusiness().getAllDirector();
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    public List getDirectorById(int id) {
        try {
            return new DirectorBusiness().getDirectorById(id);
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    public List getAllDirectoresWithOrder() {
        try {
            return new DirectorBusiness().getDirectoresWithOrder();
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    public List getAllDirectoresWithGroup() {
        try {
            return new DirectorBusiness().getDirectorWithGroupBy();
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    public int updateDirector(int id) {
        try {
            return new DirectorBusiness().updateDirector(id);
        } catch (Exception e) {
            e.printStackTrace();
            return -1;
        }
    }

    public void setNewDirector() {
        try {
            new DirectorBusiness().setNewDirector();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public int deleteDirectorById(int id) {
        try {
            return new DirectorBusiness().deleteDirector(id);
        } catch (Exception e) {
            e.printStackTrace();
            return -1;
        }
    }
}
