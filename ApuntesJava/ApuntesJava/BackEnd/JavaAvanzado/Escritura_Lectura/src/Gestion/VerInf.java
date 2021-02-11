package Gestion;

import java.io.File;

public class VerInf {
    public static void main(String[] args) {
        System.out.println("Informacion sobre el fichero");
        File f = new File("FichTexto_escritura");

        System.out.println("Nombre del fichero: " + f.getName());
        System.out.println("Ruta: " + f.getPath());
        System.out.println("Ruta absoluta: " + f.getAbsolutePath());
        System.out.println("Se puede escribir: " + f.canRead());
        System.out.println("se puede leer: " + f.canWrite());
        System.out.println("Tama�o: " + f.length());
    }
}
