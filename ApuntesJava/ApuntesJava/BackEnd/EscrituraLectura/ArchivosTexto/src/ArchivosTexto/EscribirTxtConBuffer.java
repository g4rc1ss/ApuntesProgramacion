package ArchivosTexto;


import java.io.BufferedWriter;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;

public class EscribirTxtConBuffer {
    public static void main(String[] args) {
        try {

            //Buffered writer deriva de la clase Writer. Esta clase a�ade un buffer para realizar
            //una lectura eficiente de caracteres.
            // Necesitamos la clase FileWriter
            BufferedWriter fichero = new BufferedWriter(new FileWriter("FichTextoBuffer.txt"));

            //BufferedReader fichero2 = new BufferedReader new FileReader("FichTexto1.txt"));

            int[] precios = {1350, 400, 890, 6200, 8730};
            int[] unidades = {5, 7, 12, 8, 30};
            String[] descripciones = {"paquetes", "lapices", "boligrafos", "carteras", "mesas"};

            for (int i = 0; i < descripciones.length; i++) {
                fichero.write(precios[i]);
                fichero.write(unidades[i]);
                fichero.write(descripciones[i] + "\n");
            }
            fichero.close();
        } catch (FileNotFoundException fn) {
            System.out.println("No se encuentra el fichero");
        } catch (IOException io) {
            System.out.println("Error de E/S ");
        }
    }
}
