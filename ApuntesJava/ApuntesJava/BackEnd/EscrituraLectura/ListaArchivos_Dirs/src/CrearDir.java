import java.io.File;
import java.io.IOException;

public class CrearDir {

    public static void main(String[] args) {
        File d = new File("NUEVODIR"); //directorio que creo a partir del actual
        File f1 = new File(d, "FICHERO1.TXT"); // Fiche
        File f2 = new File(d, "FICHERO2.TXT");

        d.mkdir();//CREAR DIRECTORIO

        try {
            if (f1.createNewFile())
                System.out.println("FICHERO1 creado correctamente...");
            else
                System.out.println("No se ha podido crear FICHERO1...");

            if (f2.createNewFile())
                System.out.println("FICHERO2 creado correctamente...");
            else
                System.out.println("No se ha podido crear FICHERO2...");
        } catch (IOException ioe) {
            ioe.printStackTrace();
        }

        File fn = new File(d, "NuevoFich");
        f1.renameTo(fn);
        //f1.renameTo(new File(d,"FICHERO1NUEVO"));//renombro FICHERO1
        //System.out.println("el nuevo nombre del fichero es: " + f1.getName());
        try {
            File f3 = new File("NUEVODIR/FICHERO3.TXT");
            f3.createNewFile();//crea FICHERO3 en NUEVODIR
        } catch (IOException ioe) {
            ioe.printStackTrace();
        }
    }
}