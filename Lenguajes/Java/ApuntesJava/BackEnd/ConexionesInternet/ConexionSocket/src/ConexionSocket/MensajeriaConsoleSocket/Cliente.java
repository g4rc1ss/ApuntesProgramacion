package ConexionSocket.MensajeriaConsoleSocket;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.Scanner;

public class Cliente {
    public Boolean ejecutar = true;
    static Socket cliente;
    static int opcion;

    public Cliente() throws Exception {
        cliente = new Socket("localhost", 9999);
        System.out.println("1 > Mandar Mensaje");
        System.out.println("2 > Leer Mensaje");
        System.out.println("99 > Cerrar cliente");
        System.out.println("Selecciona una opcion> ");
        Scanner teclado = new Scanner(System.in);

        while (ejecutar) {
            opcion = teclado.nextInt();
            switch (opcion) {
                case 1:
                    System.out.println("Escribe el mensaje a mandar");
                    teclado.nextLine();
                    String mensaje = teclado.nextLine();
                    mandarMensaje(mensaje);
                    break;
                case 2:
                    System.out.println("Leyendo mensaje...");
                    leerMensaje();
                    break;
                case 99:
                    System.out.println("Cliente cerrado");
                    ejecutar = false;
                    break;
            }
        }
    }

    private static void leerMensaje() throws Exception {
        ObjectInputStream paquete_datos = new ObjectInputStream(cliente.getInputStream());
        String mensaje = paquete_datos.readUTF();

        System.out.println(mensaje);
    }

    private static void mandarMensaje(String mensaje) {
        try {
            try (ObjectOutputStream escribir = new ObjectOutputStream(cliente.getOutputStream())) {
                escribir.writeUTF(mensaje);
            }
        } catch (IOException ex) {
        }
    }
}
