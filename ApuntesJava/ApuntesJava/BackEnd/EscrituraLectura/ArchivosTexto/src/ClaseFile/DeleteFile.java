package ClaseFile;

import java.io.File;

public class DeleteFile {
    public DeleteFile(String... nombreArchivos) {
        for (var nombreArchivo : nombreArchivos) {
            var archivo = new File(nombreArchivo);
            archivo.delete();
        }
    }
}
