import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class Main {
    static BufferedReader br = new BufferedReader(new InputStreamReader(System.in));

    public static void main(String[] args) {
        String nombre;
        int edad;
        try {
            nombre = pedirNombre();
            edad = pedirEdad();
            Persona p = new Persona(nombre, edad);
            System.out.println(p);
        } catch (Exception e) {
            System.out.println("ERROR AL CREAR LA PERSONA");
            pararPrograma();
        }
    }

    private static String pedirNombre() {
        System.out.println("Introduce el nombre de la persona:");
        String nombre = "";
        try {
            nombre = br.readLine();
            if (nombre.matches(".*\\d.*")) {
                throw new Exception();
            }
        } catch (Exception e) {
            System.out.println("ERROR AL INTRODUCIR EL NOMBRE");
            pararPrograma();
        }
        return nombre;
    }

    private static int pedirEdad() {
        System.out.println("Introduce la edad de la persona:");
        int edad = 0;
        try {
            edad = Integer.parseInt(br.readLine());
        } catch (Exception e) {
            System.out.println("ERROR AL INTRODUCIR LA EDAD");
            pararPrograma();
        }
        return edad;
    }

    /*
     * Cambio para detener el programa en caso de que se produzca una excepcion
     *
     * El motivo por el cual se creaba igualmente el objeto es porque los metodos estaban con try{} catch(){}
     * se capturaba la excepcion y retornaba un valor asignado por defecto, se podrian quitar los try catch, pero creo
     * que es mejor detener el programa con la sentencia "System.exit()"
     * */
    private static void pararPrograma() {
        System.err.println("Se va a detener el programa por el error producido");
        System.exit(1);
    }
}