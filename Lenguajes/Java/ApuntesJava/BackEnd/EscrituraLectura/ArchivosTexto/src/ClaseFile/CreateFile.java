package ClaseFile;

import java.io.File;
import java.io.IOException;

public class CreateFile {
    public CreateFile(String nombreArchivo) throws IOException {
        File archivo = new File(nombreArchivo);
        archivo.createNewFile();
    }
}
