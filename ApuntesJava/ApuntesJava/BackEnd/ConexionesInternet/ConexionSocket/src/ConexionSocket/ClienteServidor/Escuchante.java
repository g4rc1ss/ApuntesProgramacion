package ConexionSocket.ClienteServidor;

import java.io.DataInputStream;
import java.io.IOException;
import java.net.Socket;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Escuchante extends Thread {
    Socket misocket;

    public Escuchante(Socket misocket) {
        this.misocket = misocket;
    }

    @Override
    public void run() {
        DataInputStream flujoEntrada = null;
        try {
            flujoEntrada = new DataInputStream(misocket.getInputStream());
            while (true)
                System.out.println("Recibiendo del Servidor: \n\t" + flujoEntrada.readUTF());

        } catch (IOException ex) {
            Logger.getLogger(Escuchante.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}