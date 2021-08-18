package ClaseRandomAccessFile;

import java.io.File;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.util.ArrayList;
import java.util.Random;

public class WriteRandomAccessFile {

    public WriteRandomAccessFile(String nombreArchivo) throws IOException {
        var valores = new ArrayList<Integer>();
        var reales = new ArrayList<Double>();

        for (int x = 0; x <= 100; x++) {
            valores.add(new Random(100000).nextInt());
            reales.add(new Random(1000000).nextDouble());
        }

        File archivo = new File(nombreArchivo);//cargamos el archivo
        RandomAccessFile escribir = new RandomAccessFile(archivo, "rw");//creamos la instancia del ficheroAleatorio

        //escribimos mediante un bucle for, los datos del array
        for (int x = 0; x < valores.size(); x++) {
            escribir.writeInt(valores.get(x));
            escribir.writeDouble(reales.get(x));
        }
    }

}