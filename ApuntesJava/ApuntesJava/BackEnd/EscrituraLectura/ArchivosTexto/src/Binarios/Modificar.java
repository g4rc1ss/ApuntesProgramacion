package Binarios;

import java.io.EOFException;
import java.io.File;
import java.io.IOException;
import java.io.RandomAccessFile;

public class Modificar {

    public void setModificar() throws Exception {
        try {
            //Cargamos el archivo
            File archivo = new File("archivo.dat");
            RandomAccessFile modificar = new RandomAccessFile(archivo, "rw");//lo instanciamos en randomAccessFile

            int puntero = 0;
            int linea = 0;
            modificar.seek(puntero);//ubicamos el puntero

            try {
                while (true) {//bucle hasta que no haya mas a leer
                    int valores = modificar.readInt();
                    double reales = modificar.readDouble();
                    /*
                     * aqui me he liado un poco y no funciona, he intentado comparar los numeros y si son mayores que 100
                     * hacer el decremento, el tema es que me he liado con la ubicacion del puntero, como ubicarlo...
                     */
                    if (reales > 100.0) {
                        puntero = (linea) * 4;
                        modificar.seek(puntero);
                        reales -= (reales * 50) / 100;
                        modificar.writeDouble(reales);
                    } else if (reales < 100.0) {
                        puntero = (linea) * 4;
                        modificar.seek(puntero);
                        reales += (reales * 50) / 100;
                        modificar.writeDouble(reales);
                    }
                    linea++;
                }
            } catch (EOFException e) {
            }
        } catch (IOException e) {
            System.out.println("No se ha podido cargar el archivo");
        }
    }
}
