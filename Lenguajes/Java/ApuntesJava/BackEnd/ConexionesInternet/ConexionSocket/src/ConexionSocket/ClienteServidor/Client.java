package ConexionSocket.ClienteServidor;

import java.io.IOException;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.Scanner;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Client {
    static Socket cliente;
    static int opcion;

    public Client() throws IOException, ClassNotFoundException {
        while (true) {
            // COMPRUEBA QUE HAY CONEXION AL SERVIDOR
            if (conexion()) {
                System.out.println();
                System.out.println("---------------------------------");
                System.out.println("------SELECCIONA UNA OPCION-------");
                System.out.println("---------------------------------");
                System.out.println("1) Dar de alta ");
                System.out.println("2) Consultar los datos por el NIF");
                System.out.println("3) Modificar los datos (buscar por NIF)");
                System.out.println("4) Dar de baja");
                System.out.println("5) Listar por Ciclo Formativo");
                System.out.println("6) Cerrar aplicacion");

                // RECOGE LA OPCION SELECCIONADA
                System.out.println("Selecciona una opcion: ");
                Scanner entrScan = new Scanner(System.in);
                opcion = Integer.parseInt(entrScan.nextLine());

                switch (opcion) {
                    case 1:
                        darAlta();
                        break;

                    case 2:
                        System.out.println("----------------------------------------");
                        System.out.println("------- SELECCIONADO -------");
                        System.out.println("----------------------------------------");
                        // Aqui le escribimos el DNI, porque el m�todo lo necesita
                        System.out.println("Escribe el dni: ");
                        Scanner entrScan2 = new Scanner(System.in);
                        String nifConsultar = entrScan2.nextLine();
                        buscadorNIF(nifConsultar);
                        break;

                    case 3:

                        System.out.println("----------------------------------------");
                        System.out.println("-------- MODIFICAR SELECCIONADO --------");
                        System.out.println("----------------------------------------");

                        System.out.println("Escribe el NIF del alumno que quieres modificar: ");
                        Scanner entrScan3 = new Scanner(System.in);
                        String nifModificar = entrScan3.nextLine();
                        modificarNIF(nifModificar);
                        break;

                    case 4:

                        System.out.println("----------------------------------------");
                        System.out.println("------- DAR DE BAJA SELECCIONADO -------");
                        System.out.println("----------------------------------------");

                        System.out.println("Escribe el NIF del alumno que quieres dar de baja: ");
                        Scanner entrScan4 = new Scanner(System.in);
                        String nifEliminar = entrScan4.nextLine();
                        eliminar(nifEliminar);
                        break;

                    case 5:

                        System.out.println("----------------------------------------");
                        System.out.println("---- LISTAR POR CICLO SELECCIONADO -----");
                        System.out.println("----------------------------------------");

                        System.out.println("Escribe el ciclo que quieres listar ");
                        Scanner entrScan5 = new Scanner(System.in);
                        String ciclo = entrScan5.nextLine();
                        listar(ciclo);
                        break;

                    case 6:

                        cerrar();
                        cliente.close();
                        return;
                }
            }
        }
    }

    // Aqui es donde se hace la conexion con el server
    public static boolean conexion() {

        String Host = "localhost";
        int Puerto = 6000;// puerto remoto
        try {
            cliente = new Socket(Host, Puerto);
            System.out.println("CONEXION ESTABLECIDA");
            return true;
        } catch (IOException ex) {
            return false;
        }

    }

    // FUNCION PARA DAR DE ALTA
    public static void darAlta() throws IOException {

        System.out.println("----------------------------------------");
        System.out.println("------- DAR DE ALTA SELECCIONADO -------");
        System.out.println("----------------------------------------");

        // DECLARAR LAS VARIABLES
        String Nombre, Apellidos, NIF, Tlf, CicloF;
        int Curso;

        // PEDIMOS INTRODUCIR LOS DATOS
        Scanner entrScan3 = new Scanner(System.in);

        System.out.println("Nombre: ");
        Nombre = entrScan3.nextLine();

        System.out.println("Apellido: ");
        Apellidos = entrScan3.nextLine();

        System.out.println("NIF: ");
        NIF = entrScan3.nextLine();

        System.out.println("Telefono: ");
        Tlf = entrScan3.nextLine();

        System.out.println("Ciclo Formativo: ");
        CicloF = entrScan3.nextLine();

        System.out.println("Introduce el Curso: ");
        Curso = Integer.parseInt(entrScan3.nextLine());

        // CREAMOS UN OBJETO
        Alumno alumno2 = new Alumno(Nombre, Apellidos, NIF, Tlf, CicloF, Curso);

        try {

            try (ObjectOutputStream perSal = new ObjectOutputStream(cliente.getOutputStream())) {
                perSal.writeInt(1);
                perSal.writeObject(alumno2);
                perSal.close();

            }

        } catch (IOException ex) {
            Logger.getLogger(Alumno.class.getName()).log(Level.SEVERE, null, ex);
        }

    }

    // FUNCION PARA CONSULTAR POR NIF
    public static void buscadorNIF(String nif) throws IOException, ClassNotFoundException {
        try {
            try (ObjectOutputStream perSal2 = new ObjectOutputStream(cliente.getOutputStream())) {
                perSal2.writeInt(2);
                perSal2.writeUTF(nif);
            }
        } catch (IOException ex) {
            Logger.getLogger(Alumno.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    // FUNCION MODIFICAR ALUMNOS
    public static void modificarNIF(String nif) throws IOException, ClassNotFoundException {
        try {

            try (ObjectOutputStream perSal2 = new ObjectOutputStream(cliente.getOutputStream())) {
                perSal2.writeInt(2);
                perSal2.writeUTF(nif);
                perSal2.close();

            }

        } catch (IOException ex) {
            Logger.getLogger(Alumno.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    // FUNCION DAR DE BAJA
    public static void eliminar(String nif) throws IOException, ClassNotFoundException {
        try {

            try (ObjectOutputStream perSal2 = new ObjectOutputStream(cliente.getOutputStream())) {
                perSal2.writeInt(4);
                perSal2.writeUTF(nif);
                perSal2.close();

            }

        } catch (IOException ex) {
            Logger.getLogger(Alumno.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    // FUNCION LISTAR POR CICLOS FORMATIVOS
    public static void listar(String ciclo) throws IOException, ClassNotFoundException {
        try {

            try (ObjectOutputStream perSal2 = new ObjectOutputStream(cliente.getOutputStream())) {
                perSal2.writeInt(5);
                perSal2.writeUTF(ciclo);
                perSal2.close();

            }

        } catch (IOException ex) {
            Logger.getLogger(Alumno.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public static void cerrar() throws IOException, ClassNotFoundException {
        try (ObjectOutputStream perSal2 = new ObjectOutputStream(cliente.getOutputStream())) {
            perSal2.writeInt(6);
            perSal2.close();
            System.out.println("El Socket se ha cerrado por lo que ya no hay conexion con el Server");

        } catch (IOException ex) {
            Logger.getLogger(Alumno.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}
