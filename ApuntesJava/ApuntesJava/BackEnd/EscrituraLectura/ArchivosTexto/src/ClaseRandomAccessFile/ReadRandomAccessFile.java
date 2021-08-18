package ClaseRandomAccessFile;

import java.io.EOFException;
import java.io.File;
import java.io.IOException;
import java.io.RandomAccessFile;

public class ReadRandomAccessFile {
    public ReadRandomAccessFile(String nombreArchivo) {
        try {
            //cargamos el fichero binario
            File archivo = new File(nombreArchivo);
            //instanciamos el fichero aleatorio y le damos permisos lectura
            RandomAccessFile leer = new RandomAccessFile(archivo, "r");
            try {
                //bucle hasta que no haya mas a leer
                while (true) {
                    int valores = leer.readInt();
                    double reales = leer.readDouble();
                    System.out.println("Valores: " + valores + " reales: " + reales);
                }
            } catch (EOFException e) {
            }
        } catch (IOException e) {
            System.out.println("No se ha podido cargar el archivo");
        }
    }

}
