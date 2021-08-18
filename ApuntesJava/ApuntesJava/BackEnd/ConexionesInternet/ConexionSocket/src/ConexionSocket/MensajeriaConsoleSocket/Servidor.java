package ConexionSocket.MensajeriaConsoleSocket;

import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.ServerSocket;
import java.net.Socket;

public class Servidor {
    public static void main(String[] args) throws Exception {
        ServerSocket servidor = new ServerSocket(9999);
        while (true) {
            Socket cliente = servidor.accept();
            ObjectInputStream paquete_datos = new ObjectInputStream(cliente.getInputStream());
            String mensaje = paquete_datos.readUTF();

            System.out.println(mensaje);

            if (!mensaje.equals("")) {
                ObjectOutputStream paquete_envio = new ObjectOutputStream(cliente.getOutputStream());
                paquete_envio.writeUTF(mensaje);
            }
        }
    }
}
