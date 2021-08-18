import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        ArrayList<Empleado> listaEmpleados = new ArrayList<>();
        for (int x = 0; x < 10; x++)
            listaEmpleados.add(new Empleado("nombre numero" + x, x + 10, 2000 + x));
        try {
            ObjectOutputStream escribirListaEmpleados = new ObjectOutputStream(
                    new FileOutputStream("archivo.dat")
            );
            escribirListaEmpleados.writeObject(listaEmpleados);

            ObjectInputStream leerListaEmpleados = new ObjectInputStream(
                    new FileInputStream("archivo.dat")
            );
            listaEmpleados.clear();
            listaEmpleados = (ArrayList<Empleado>) leerListaEmpleados.readObject();

            for (Empleado empleado : listaEmpleados) {
                System.out.println( "Nombre: " + empleado.getNombre()
                        + "\nEdad: " + empleado.getEdad()
                        + "\nSueldo: " + empleado.getSueldo()
                        + "\nClave: " + empleado.getClaveDefecto());
                System.out.println("-----------------------------");
            }
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
