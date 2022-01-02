package ConexionSocket;

import java.io.IOException;
import java.net.Socket;
import java.util.Scanner;

public class PortScan {
    Socket socket = null;
    Scanner teclado;
    static String host;
    static int iPort = 0;
    static int fPort = 0;
    static int port;
    int[] puertosMasUsados = {21, 22, 80, 443, 55};

    public boolean conexion(String host, int port) {
        try {
            socket = new Socket(host, port);
            return true;
        } catch (IOException e) {
            return false;
        }
    }

    public void menu() {
        teclado = new Scanner(System.in);

        System.out.print(
                "1. 1 o mas puertos\n" +
                        "2. los puertos mas usados\n" +
                        "99. Salir\n" +
                        "#>\t");
        int opcion = teclado.nextInt();

        if (opcion == 99)
            return;
        else {
            System.out.println("Introduce el host a analizar");
            teclado.nextLine();
            host = teclado.nextLine();

            switch (opcion) {
                case 1:
                    System.out.println("Puerto de inicio");
                    iPort = teclado.nextInt();

                    System.out.println("Quieres un rango o solo uno?");
                    teclado.nextLine();
                    String opcionstr = teclado.nextLine();
                    if (opcionstr.equals("rango")) {
                        System.out.println("Puerto fin");
                        fPort = teclado.nextInt();
                    }
                    puertosTeclado();
                    break;
                case 2:
                    puertosUsados();
                    break;
            }
        }
    }

    public void puertosTeclado() {
        port = iPort;
        if (fPort != 0) {
            while (fPort >= port && iPort <= port) {
                comprobacion(conexion(host, port));
                port++;
            }
        } else
            comprobacion(conexion(host, port));
    }

    public void puertosUsados() {
        for (int i = 0; i < puertosMasUsados.length; i++) {
            port = puertosMasUsados[i];
            comprobacion(conexion(host, port));
        }
    }

    public void comprobacion(boolean comprobar) {
        if (comprobar)
            System.out.println("[+] " + port + " Abierto");
        else
            System.out.println("[-] " + port + " Cerrado");
    }
}
