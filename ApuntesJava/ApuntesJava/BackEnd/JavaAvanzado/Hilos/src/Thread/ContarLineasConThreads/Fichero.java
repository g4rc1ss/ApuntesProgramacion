package Thread.ContarLineasConThreads;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

public class Fichero extends Thread {

    private String nombre;
    static int maximo;
    static String ficherogrande;

    public Fichero(String nombre) {
        this.nombre = nombre;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    @Override
    public void run() {
        try {
            FileReader fr = new FileReader(this.nombre);
            BufferedReader bf = new BufferedReader(fr);
            int lNumeroLineas = 0;

            while (bf.readLine() != null)
                lNumeroLineas++;

            System.out.println("El número de linea de " + this.nombre + " es de " + lNumeroLineas);
            if (lNumeroLineas > maximo) {
                maximo = lNumeroLineas;
                ficherogrande = this.nombre;
            }
        } catch (FileNotFoundException ex) {
            Logger.getLogger(Fichero.class.getName()).log(Level.SEVERE, null, ex);
        } catch (IOException ex) {
            Logger.getLogger(Fichero.class.getName()).log(Level.SEVERE, null, ex);
        }

    }

}
