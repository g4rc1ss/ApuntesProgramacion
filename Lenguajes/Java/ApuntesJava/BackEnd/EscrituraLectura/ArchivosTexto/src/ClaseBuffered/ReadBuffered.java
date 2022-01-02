package ClaseBuffered;


import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

public class ReadBuffered {
    public ReadBuffered(String nombreArchivo) {
        try {
            BufferedReader fichero = new BufferedReader(new FileReader(nombreArchivo));

            String linea;
            while ((linea = fichero.readLine()) != null)
                System.out.println(linea);
            fichero.close();
        } catch (FileNotFoundException fn) {
            System.out.println("No se encuentra el fichero");
        } catch (IOException io) {
            System.out.println("Error de E/S ");
        }
    }
}
