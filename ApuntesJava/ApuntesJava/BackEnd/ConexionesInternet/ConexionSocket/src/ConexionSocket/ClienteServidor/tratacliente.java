/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package internet.ConexionSocket.ClienteServidor;

import java.io.*;
import java.net.Socket;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author david
 */
public class tratacliente extends Thread{
        Socket micliente;
        ArrayList <Socket>misclientes;
        tratacliente(Socket cC, ArrayList <Socket>misclientes){
        micliente=cC;
        this.misclientes=misclientes;
    }
        @Override
    public void run(){
        while(true){
            InputStream entrada = null;
            OutputStream salida=null;
            try {
                entrada = micliente.getInputStream();
                               
                 DataInputStream flujoEntrada = new DataInputStream(entrada);
                String mensaje = flujoEntrada.readUTF();
                System.out.println("Recibiendo del Cliente: \n\t" + mensaje);
                for(int i=0;i<misclientes.size();i++)
                {
                     salida = misclientes.get(i).getOutputStream();
                   DataOutputStream flujosalida = new DataOutputStream(salida);
                   flujosalida.writeUTF(mensaje);
                }
              
                
            } catch (IOException ex) {
                Logger.getLogger(Servidor.class.getName()).log(Level.SEVERE, null, ex);
            }
          
        }
    }
}
