import ClaseBuffered.ReadBuffered;
import ClaseBuffered.WriteBuffered;
import ClaseFile.CopyFile;
import ClaseFile.CreateFile;
import ClaseFile.DeleteFile;
import ClaseRandomAccessFile.ReadRandomAccessFile;
import ClaseRandomAccessFile.WriteRandomAccessFile;
import ClaseStream.ReadStream;
import ClaseStream.WriteStream;

import java.io.IOException;

public class ArchivosTextoMain {

    private static final String NOMBRE_ARCHIVO_BUFFERED = "ArchivoBuffer.bin";
    private static final String NOMBRE_ARCHIVO_RANDOM_ACCESS_FILE = "ArchivoRandomAccessFile.bin";
    private static final String NOMBRE_ARCHIVO_STREAM = "ArchivoStream.bin";
    private static final String NOMBRE_ARCHIVO_FILE_ORIGEN = "ArchivoFile.bin";
    private static final String NOMBRE_ARCHIVO_FILE_DESTINO = "ArchivoFileDestino.bin";

    public static void main(String[] args) throws IOException {
        System.out.println("USANDO CLASE BUFFERED");
        new WriteBuffered(NOMBRE_ARCHIVO_BUFFERED);
        new ReadBuffered(NOMBRE_ARCHIVO_BUFFERED);

        System.out.println("\n-----------------------------------------------------------\n");

        System.out.println("USANDO CLASE RANDOM ACCESS FILE");
        new WriteRandomAccessFile(NOMBRE_ARCHIVO_RANDOM_ACCESS_FILE);
        new ReadRandomAccessFile(NOMBRE_ARCHIVO_RANDOM_ACCESS_FILE);

        System.out.println("\n-----------------------------------------------------------\n");

        System.out.println("USANDO CLASE STREAM");
        new WriteStream(NOMBRE_ARCHIVO_STREAM);
        new ReadStream(NOMBRE_ARCHIVO_STREAM);

        System.out.println("\n-----------------------------------------------------------\n");

        System.out.println("USANDO CLASE FILE");
        new CreateFile(NOMBRE_ARCHIVO_FILE_ORIGEN);
        new CopyFile(NOMBRE_ARCHIVO_FILE_ORIGEN, NOMBRE_ARCHIVO_FILE_DESTINO);
        new DeleteFile(NOMBRE_ARCHIVO_BUFFERED, NOMBRE_ARCHIVO_RANDOM_ACCESS_FILE, NOMBRE_ARCHIVO_STREAM, NOMBRE_ARCHIVO_FILE_ORIGEN, NOMBRE_ARCHIVO_FILE_DESTINO);
    }
}
