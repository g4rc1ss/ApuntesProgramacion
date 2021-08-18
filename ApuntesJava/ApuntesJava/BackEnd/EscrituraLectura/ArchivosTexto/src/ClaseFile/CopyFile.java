package ClaseFile;

import java.io.*;

public class CopyFile {
    public CopyFile(String nombreArchivoOrigen, String nombreArchivDestino) {
        File origin = new File(nombreArchivoOrigen);
        File destination = new File(nombreArchivDestino);
        if (origin.exists()) {
            try {
                InputStream in = new FileInputStream(origin);
                OutputStream out = new FileOutputStream(destination);
                // We use a buffer for the copy (Usamos un buffer para la copia).
                byte[] buf = new byte[1024];
                int len;
                while ((len = in.read(buf)) > 0) {
                    out.write(buf, 0, len);
                }
                in.close();
                out.close();
            } catch (IOException ioe) {
                ioe.printStackTrace();
            }
        }
    }
}
