package ConexionSocket.BBDD_Alumnos;

import java.io.*;
import java.net.ServerSocket;
import java.net.Socket;

public class Server {

    static Socket cliente;
    static Alumno buscar;
    static int op;

    public static void main(String[] args) throws IOException, ClassNotFoundException {

        int numeroPuerto = 6000;// Puerto
        ServerSocket servidor = new ServerSocket(numeroPuerto);

        while (true) {
            System.out.println("ESPERANDO CONEXION");

            cliente = servidor.accept();

            try (ObjectInputStream inObjeto = new ObjectInputStream(cliente.getInputStream())) {

                // RECIBE LOS DATOS
                op = inObjeto.readInt();

                switch (op) {
                    case 1:
                        System.out.println("DAR DE ALTA SELECCIONADO");
                        darAltaAlumno(inObjeto);
                        break;

                    case 2:
                        System.out.println("BUSCADOR SELECCIONADO");
                        buscadorNIF(inObjeto);
                        break;

                    case 3:
                        System.out.println("MODIFICAR SELECCIONADO");
                        modificarNIF(inObjeto);
                        break;

                    case 4:
                        System.out.println("DAR DE BAJA SELECCIONADO");
                        eliminar(inObjeto);
                        break;

                    case 5:
                        System.out.println("LISTAR SELECCIONADO");
                        listar(inObjeto);
                        break;
                    case 6:
                        System.out.println("Fin de la conexión");
                        salir(inObjeto);
                        return;

                }

            }

        }
    }

    public static void darAltaAlumno(ObjectInputStream inObjeto2) throws IOException, ClassNotFoundException {

        buscar = (Alumno) inObjeto2.readObject();
        FileOutputStream archivo = new FileOutputStream("datos.dat", true);
        // salida.writeObject(buscar);
        try (ObjectOutputStream salida = new ObjectOutputStream(archivo)) {
            salida.writeObject(buscar);
            salida.close();
            // salida.writeUnshared(buscar);
        }

    }

    public static void buscadorNIF(ObjectInputStream inObjetos)
            throws FileNotFoundException, IOException, ClassNotFoundException {

        String fichero = "datos.dat";
        String niffichero = "";
        String bnif = inObjetos.readUTF();

        FileInputStream mifichero = new FileInputStream(fichero);
        try {
            while (true) {
                ObjectInputStream ois = new ObjectInputStream(mifichero);
                Alumno a;
                try {
                    a = (Alumno) ois.readObject();
                    if (a.getNIF().compareTo(bnif) == 0) {
                        System.out.println("Alumno encontrado");
                        System.out.println(a.getNombre() + a.getApellidos());

                        break;
                    }
                } catch (EOFException e) {
                    System.out.println(e);
                    break;
                }

                niffichero = a.getNIF();
                // System.out.println("Leo del fichero el NIF"+ niffichero);
                if (mifichero.available() == 0) {
                    System.out.println("Alumno No encontrado");
                    break;

                }
            }
        } finally {
            mifichero.close();
        }

    }

    public static void modificarNIF(ObjectInputStream inObjetos)
            throws FileNotFoundException, IOException, ClassNotFoundException {

        try (ObjectInputStream entrada = new ObjectInputStream(new FileInputStream("alumnos.dat"))) {
            Alumno obj1 = (Alumno) entrada.readObject();
            if (obj1.getNIF().equals(inObjetos.readUTF())) {
                System.out.println("USUARIO ENCONTRADO");

            } else {
                System.err.println("USUARIO NO EXISTE");
            }
            entrada.close();
        }
        inObjetos.close();

    }

    public static void eliminar(ObjectInputStream inObjetos)
            throws FileNotFoundException, IOException, ClassNotFoundException {

        String fichero = "datos.dat";
        String ficheroaux = "datosaux.dat";
        String niffichero = "";
        String bnif = inObjetos.readUTF();
        int sw = 0;

        FileInputStream mifichero = new FileInputStream(fichero);
        FileOutputStream mificheroaux = new FileOutputStream(ficheroaux, true);
        try {
            while (true) {
                ObjectInputStream ois = new ObjectInputStream(mifichero);

                Alumno a;
                try {
                    a = (Alumno) ois.readObject();
                    if (a.getNIF().compareTo(bnif) != 0) {
                        ObjectOutputStream oos = new ObjectOutputStream(mificheroaux);
                        oos.writeObject(a);

                    } else {
                        sw = 1;
                    }

                } catch (EOFException e) {
                    System.out.println(e);
                    break;
                }

                niffichero = a.getNIF();
                // System.out.println("Leo del fichero el NIF"+ niffichero);
                if (mifichero.available() == 0) {
                    // fin fichero
                    break;

                }

            }
        } finally {
            mifichero.close();
            if (sw == 0) {
                System.out.println("Alumno No encontrado");
            } else {
                mifichero.close();
                mificheroaux.close();
                File a = new File("datos.dat");
                a.delete();
                File b = new File("datosaux.dat");
                b.renameTo(a);
                System.out.println("Alumno dado de baja");

            }
        }

    }

    public static void listar(ObjectInputStream inObjetos)
            throws FileNotFoundException, IOException, ClassNotFoundException {

        int sw = 0;
        String fichero = "datos.dat";
        String niffichero = "";
        String bciclo = inObjetos.readUTF();
        System.out.println("Listado de alumnos del Ciclo: " + bciclo);
        FileInputStream mifichero = new FileInputStream(fichero);
        try {
            while (true) {
                ObjectInputStream ois = new ObjectInputStream(mifichero);
                Alumno a;
                try {
                    a = (Alumno) ois.readObject();
                    System.out.println("Ciclo del alumno leido: " + a.getCicloForm());
                    if (a.getCicloForm().compareTo(bciclo) == 0) {
                        System.out.println(a.getNombre() + a.getApellidos());
                        sw = 1;

                    }
                } catch (EOFException e) {
                    System.out.println(e);
                    break;
                }

                if (mifichero.available() == 0) {
                    // fin fichero
                    break;

                }
            }
        } finally {
            mifichero.close();
            if (sw == 0)
                System.out.println("No hay alumnos en ese ciclo");
        }

    }

    public static void salir(ObjectInputStream inObjetos) throws FileNotFoundException, IOException, ClassNotFoundException {
        inObjetos.close();
    }

}
