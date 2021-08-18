import garaje.mecanico.GestionTrabajos;
import garaje.mecanico.herencias.ReparacionChapaPintura;
import garaje.mecanico.herencias.ReparacionMecanica;
import garaje.mecanico.herencias.Revision;

import java.util.Scanner;

public class Main {
    private Scanner scanner = new Scanner(System.in);
    private GestionTrabajos gestionTrabajos = new GestionTrabajos();

    public static void main(String[] args) {
        new Main().menu();
    }

    private void menu() {
        boolean continuarMenu, comprobar;
        int idTrabajo;
        double numHoras, costePiezas;
        do {
            System.out.println("" +
                    "1.> Registrar Trabajo \n" +
                    "2-> Aumentar Horas \n" +
                    "3-> Aumentar coste Piezas \n" +
                    "4-> Finalizar trabajo \n" +
                    "5-> Mostrar trabajo \n" +
                    "99-> Cerrar programa \n" +
                    "> "
            );
            String opcion = scanner.nextLine();
            switch (opcion) {
                case "1":
                    Object tipoTrabajo;
                    System.out.println("" +
                            "Selecciona el tipo de trabajo \n" +
                            "1-> Reparacion Mecanica \n" +
                            "2-> Reparacion De Chapa y Pintura \n" +
                            "3-> Revision");
                    int optTipoTrabajo = scanner.nextInt();
                    if (optTipoTrabajo == 1)
                        tipoTrabajo = new ReparacionMecanica();
                    else if (optTipoTrabajo == 2)
                        tipoTrabajo = new ReparacionChapaPintura();
                    else
                        tipoTrabajo = new Revision();

                    System.out.println("Teclea una descripcion del trabajo");
                    scanner.nextLine();
                    String descripcion = scanner.nextLine();

                    int id = gestionTrabajos.registrarTrabajo(tipoTrabajo, descripcion);
                    System.out.println("Identificador del trabajo: " + id);
                    break;

                case "2":
                    System.out.println("Teclea el codigo del trabajo");
                    idTrabajo = scanner.nextInt();
                    System.out.println("Teclea el numero de horas a agregar");
                    numHoras = scanner.nextDouble();
                    scanner.nextLine(); // Limpiamos el buffer del scanner

                    comprobar = gestionTrabajos.aumentarHoras(idTrabajo, numHoras);
                    if (!comprobar)
                        System.out.println("No se pueden agregar mas horas a una tarea ya finalizada");
                    break;

                case "3":
                    System.out.println("Teclea el codigo del trabajo");
                    idTrabajo = scanner.nextInt();
                    System.out.println("Teclea el coste de las piezas");
                    costePiezas = scanner.nextDouble();
                    scanner.nextLine(); // Limpiamos el buffer del scanner

                    comprobar = gestionTrabajos.aumentarCostePiezas(idTrabajo, costePiezas);
                    if (!comprobar)
                        System.out.println("No se pueden agregar mas horas a una tarea ya finalizada");
                    break;

                case "4":
                    System.out.println("Teclea el codigo del trabajo");
                    idTrabajo = scanner.nextInt();
                    scanner.nextLine(); // Limpiamos el buffer del scanner

                    gestionTrabajos.finalizarTrabajo(idTrabajo);
                    break;

                case "5":
                    System.out.println("Teclea el codigo del trabajo");
                    idTrabajo = scanner.nextInt();
                    scanner.nextLine(); // Limpiamos el buffer del scanner

                    String datosMostrar = gestionTrabajos.mostrarTrabajo(idTrabajo);
                    System.out.println(datosMostrar);
                    break;

                case "99":
                    System.exit(0);
                    break;
                default:
                    System.out.println("Introduce una de las opciones \n " +
                            "Por introducir mal la opcion, vuelve a ejecutar el programa :P");
                    System.exit(-1);
            }
            System.out.println("Desea continuar?");
            continuarMenu = scanner.nextLine().toUpperCase().startsWith("S");
        } while (continuarMenu);
        System.exit(0);
    }
}
