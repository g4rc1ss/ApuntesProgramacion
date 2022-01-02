package EscribirObjeto;


import Entidades.Empleado;

import java.io.FileOutputStream;
import java.io.ObjectOutputStream;
import java.util.ArrayList;

public class WriteObject {
    public WriteObject(String nombreArchivo) {
        ArrayList<Empleado> listaEmpleados = new ArrayList<>();
        for (int x = 0; x < 10; x++)
            listaEmpleados.add(new Empleado("nombre numero" + x, x + 10, 2000 + x));
        try {
            ObjectOutputStream escribirListaEmpleados = new ObjectOutputStream(
                    new FileOutputStream(nombreArchivo)
            );
            escribirListaEmpleados.writeObject(listaEmpleados);
            escribirListaEmpleados.close();
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
