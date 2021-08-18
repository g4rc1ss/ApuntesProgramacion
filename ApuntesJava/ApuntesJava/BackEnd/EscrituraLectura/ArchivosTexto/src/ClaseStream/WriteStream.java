package ClaseStream;

import java.io.DataOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;

public class WriteStream {
    FileOutputStream fileout;
    DataOutputStream dataout;

    public WriteStream(String nombreArchivo) throws IOException {
        try {

            File fichero = new File(nombreArchivo);

            fileout = new FileOutputStream(fichero);
            dataout = new DataOutputStream(fileout);

            String nombres[] = {"Ricardo", "Endika", "Andoni"};
            int edades[] = {20, 21, 22};

            for (int i = 0; i < nombres.length; i++) {
                dataout.writeUTF(nombres[i]);
                dataout.writeInt(edades[i]);
            }
        } finally {
            assert dataout != null;
            dataout.close();
            fileout.close();
        }
    }
}
