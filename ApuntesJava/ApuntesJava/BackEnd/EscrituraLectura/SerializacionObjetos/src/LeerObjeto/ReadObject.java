package LeerObjeto;

import Entidades.Empleado;

import java.io.FileInputStream;
import java.io.ObjectInputStream;
import java.util.ArrayList;

public class ReadObject {
    public ReadObject(String nombreArchivo) {
        ArrayList<Empleado> listaEmpleados = new ArrayList<>();
        for (int x = 0; x < 10; x++)
            listaEmpleados.add(new Empleado("nombre numero" + x, x + 10, 2000 + x));
        try {
            ObjectInputStream leerListaEmpleados = new ObjectInputStream(
                    new FileInputStream(nombreArchivo)
            );

            var objetoLeido = (ArrayList<Empleado>) leerListaEmpleados.readObject();

            for (Empleado empleado : objetoLeido) {
                System.out.println("Nombre: " + empleado.getNombre()
                        + "\nEdad: " + empleado.getEdad()
                        + "\nSueldo: " + empleado.getSueldo()
                        + "\nClave: " + empleado.getClaveDefecto());
                System.out.println("-----------------------------");
                leerListaEmpleados.close();
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
