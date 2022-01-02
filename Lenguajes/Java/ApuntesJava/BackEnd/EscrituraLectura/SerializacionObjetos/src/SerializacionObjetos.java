import EscribirObjeto.WriteObject;
import LeerObjeto.ReadObject;

import java.io.File;

public class SerializacionObjetos {
    private static final String NOMBRE_ARCHIVO = "ArchivoSerializado.dat";

    public static void main(String[] args) {
        try {
            new WriteObject(NOMBRE_ARCHIVO);
            new ReadObject(NOMBRE_ARCHIVO);
        } finally {
            File archivo = new File(NOMBRE_ARCHIVO);
            archivo.delete();
        }
    }
}
