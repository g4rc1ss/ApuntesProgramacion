import ConexionSocket.ClienteServidor.Client;
import ConexionSocket.ClienteServidor.Server;
import ConexionSocket.MensajeriaConsoleSocket.Cliente;
import ConexionSocket.MensajeriaConsoleSocket.Servidor;

import java.io.File;

public class Conexiones {

    private static final String NOMBRE_ARCHIVO_BBDD = "datos.dat";

    public static void main(String[] args) throws Exception {

        try {
            // CLIENTE-SERVIDOR BBDD DE ALUMNOS
            new Thread(() -> {
                try {
                    new Server(NOMBRE_ARCHIVO_BBDD);
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }).start();
            new Client();

            // CLIENTE-SERVIDOR ENVIO DE MENSAJES NORMAL
            new Thread(() -> {
                try {
                    new Servidor();
                } catch (Exception e) {
                    e.printStackTrace();
                }
            }).start();
            new Cliente();

            // ESCANER DE PUERTOS DE UN SISTEMA
            new ConexionSocket.PortScan().menu();
        } finally {
            var archivo = new File(NOMBRE_ARCHIVO_BBDD);
            archivo.delete();

            System.exit(0);
        }
    }
}

