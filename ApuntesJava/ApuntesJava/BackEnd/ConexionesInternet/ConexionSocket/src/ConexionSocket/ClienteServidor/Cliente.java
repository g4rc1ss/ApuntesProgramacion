package ConexionSocket.ClienteServidor;

import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.Scanner;

public class Cliente {
    public static void main(String[] args) throws IOException {
        String Host = "localhost";// ip de conexión
        int Puerto = 6000;// puerto conexión
        System.out.println("Programa ClienteSocket Iniciado...");
        Socket ClienteSocket = new Socket(Host, Puerto); // realizamos la conexión por medio socket
        DataOutputStream flujoSalida = new DataOutputStream(ClienteSocket.getOutputStream());
        System.out.println("Dime nombre de usuario: ");
        Scanner scanner = new Scanner(System.in);
        String nombrecliente = scanner.nextLine();
        flujoSalida.writeUTF(nombrecliente);// mando mensaje al servidor con nombre cliente
        Escuchante t = new Escuchante(ClienteSocket);
        t.start();
        while (true) {
            System.out.println("Escriba un mensaje al Servidor");
            scanner = new Scanner(System.in);
            String mensaje = scanner.nextLine();
            flujoSalida.writeUTF(mensaje);

        }

    }

}
