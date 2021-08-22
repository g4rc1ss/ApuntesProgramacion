import GUI.InterfazPrincipal;

import java.io.File;
import java.io.FileWriter;

public class Main {
    private static final String ARCHIVO_CONFIG_CREDENTIALS = "credenciales.config";

    public static void main(String[] args) {
        crearFichero();
        new InterfazPrincipal();

        Runtime.getRuntime().addShutdownHook(new Thread(() -> {
            var archivo = new File(ARCHIVO_CONFIG_CREDENTIALS);
            archivo.delete();
        }));
    }

    /*
     * He creado este metodo para que no haya problemas de rutas a la hora de
     * leer el fichero, puesto que depende de con que IDE ejecutes, se ubica en una ruta
     * u otra
     * */
    static void crearFichero() {
        FileWriter fileWriter;
        try {
            fileWriter = new FileWriter(ARCHIVO_CONFIG_CREDENTIALS);
            fileWriter.write("usuario=USER \n" +
                    "password=12345 \n" +
                    "nombrePersona=Mikel es USER \n");
            fileWriter.close();
        } catch (Exception ignored) {
            System.exit(-1);
        }
    }
}
