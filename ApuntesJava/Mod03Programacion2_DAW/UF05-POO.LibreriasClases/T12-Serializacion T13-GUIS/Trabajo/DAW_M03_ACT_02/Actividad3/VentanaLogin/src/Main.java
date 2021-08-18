import GUI.InterfazPrincipal;

import java.io.FileWriter;

public class Main {
    public static void main(String[] args) {
        crearFichero();
        new InterfazPrincipal();
    }

    /*
    * He creado este metodo para que no haya problemas de rutas a la hora de
    * leer el fichero, puesto que depende de con que IDE ejecutes, se ubica en una ruta
    * u otra
    * */
    static void crearFichero() {
        FileWriter fileWriter;
        try {
            fileWriter = new FileWriter("credenciales.config");
            fileWriter.write("usuario=USER \n" +
                    "password=12345 \n" +
                    "nombrePersona=Mikel es USER \n");
            fileWriter.close();
        } catch (Exception ignored) {
            System.exit(-1);
        }
    }
}
