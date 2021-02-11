package ORMHibernate._01_FrontendLogic;

import ORMHibernate._02_BackendBusinessLogic.Action.DirectorAction;

import java.util.Random;

public class DirectorConsole {
    public DirectorConsole() {
    }

    public void getDirector() {
        System.out.println("------------------ DIRECTORES ----------------------");
        var directores = new DirectorAction().getAllDirector();
        directores.parallelStream().forEach(director -> {
            System.out.println(director.toString());
        });

        System.out.println("------------------ DIRECTOR POR ID ----------------------");
        var directorById = new DirectorAction().getDirectorById(2);
        for (var director : directorById) {
            System.out.println(director.toString());
        }

        System.out.println("------------------ DIRECTOR CON ORDEN ----------------------");
        var directoresWithOrder = new DirectorAction().getAllDirectoresWithOrder();
        directoresWithOrder.parallelStream().forEachOrdered(director -> {
            System.out.println(director.toString());
        });

        System.out.println("------------------ DIRECTOR POR GRUPO ----------------------");
        var directoresWithGroup = new DirectorAction().getAllDirectoresWithGroup();
        directoresWithGroup.parallelStream().forEach(director -> {
            System.out.println(director.toString());
        });

        System.out.println("------------------ UPDATE DIRECTOR ----------------------");
        var updateDirector = new DirectorAction().updateDirector(new Random().nextInt(directores.size()));
        System.out.println("Se han actualizado " + updateDirector + " registros");

        System.out.println("------------------ BORRAR DIRECTOR ----------------------");
        var deleteDirector = new DirectorAction().deleteDirectorById(new Random().nextInt(directores.size()));
        System.out.println("Se han borrado " + deleteDirector + " registros");

        System.out.println("------------------ DIRECTOR POR ID ----------------------");
        new DirectorAction().setNewDirector();
        System.out.println("Director Creado");
    }
}
