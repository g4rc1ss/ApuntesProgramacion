package ClaseStream;

import java.io.*;

public class ReadStream {
    FileInputStream filein;
    DataInputStream datain;

    public ReadStream(String nombreArchivo) throws IOException {
        try {

            File fichero = new File(nombreArchivo);

            filein = new FileInputStream(fichero);
            datain = new DataInputStream(filein);

            String nombres[] = {"Ricardo", "Endika", "Andoni"};
            int edades[] = {20, 21, 22};

            try {
                while (true) {
                    System.out.println("Nombre: " + datain.readUTF() + ", Edad: " + datain.readInt());
                }
            } catch (EOFException eo) {
                System.out.println("Fin del fichero");
            }
        } finally {
            assert datain != null;
            datain.close();
            filein.close();
        }
    }
}
