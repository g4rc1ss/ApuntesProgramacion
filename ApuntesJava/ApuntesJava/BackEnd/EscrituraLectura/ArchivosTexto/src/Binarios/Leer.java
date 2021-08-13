package Tratamiento.Binarios;

import java.io.EOFException;
import java.io.File;
import java.io.IOException;
import java.io.RandomAccessFile;

public class Leer {
    public static void main(String[] args) {
        try {
            File archivo = new File("archivo.dat");//cargamos el fichero binario
            RandomAccessFile leer = new RandomAccessFile(archivo, "r");//instanciamos el fichero aleatorio y le damos permisos lectura
            try {
                while (true) {//bucle hasta que no haya mas a leer
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
