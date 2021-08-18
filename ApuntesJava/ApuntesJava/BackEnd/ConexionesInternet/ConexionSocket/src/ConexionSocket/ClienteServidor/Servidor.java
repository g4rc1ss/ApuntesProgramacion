package ConexionSocket.ClienteServidor;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;

public class Servidor {
    public static void main(String[] args) throws IOException {
        int numeroPuerto = 6000;
        String mensaje;
        ArrayList<Socket> misclientes = new ArrayList();

        ServerSocket servidor = new ServerSocket(numeroPuerto);
        Socket clienteConectado = null;
        System.out.println("Esperando al cliente....");

        while (true) {
            clienteConectado = servidor.accept();
            misclientes.add(clienteConectado);
            System.out.println("Se ha conectado el cliente " + clienteConectado.getInetAddress().getHostName());
            tratacliente t = new tratacliente(clienteConectado, misclientes);
            t.start();
        }
    }
}
