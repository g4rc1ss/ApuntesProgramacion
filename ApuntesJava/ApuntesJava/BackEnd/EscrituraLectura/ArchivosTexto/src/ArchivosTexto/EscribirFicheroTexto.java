package ArchivosTexto;

import java.io.File;
import java.io.FileWriter;

public class EscribirFicheroTexto {
    public EscribirFicheroTexto() {
        try {
            File fichero = new File("FichTexto_escritura.txt");// declara fichero

            FileWriter fic = new FileWriter(fichero); // crear el flujo de salida

            String cadena = "Esto es una prueba con FileWriter";
            char[] cad = cadena.toCharArray();// convierte un String en array de caracteres

            for (int i = 0; i < cad.length; i++)
                fic.write(cad[i]); // se va escribiendo un car�cter

            fic.append('*'); // a�ado al final un *
            // fic.write(cad);//en vez de escribir de uno en uno, se escribe un array de
            // caracteres
            String c = "\n*esto es lo ultimo*";
            fic.write(c);// escribir un String

            String prov[] = {"Albacete ", "Avila ", "Badajoz ", "Caceres ", "Huelva ", "Jaen ", "Madrid ", "Segovia ",
                    "Soria ", "Toledo  ", "Valladolid ", "Zamora "};

            fic.write("\n");
            for (int i = 0; i < prov.length; i++) {
                fic.write(prov[i]);
                fic.write("\n");
            }
            fic.close(); // cerrar fichero
        } catch (Exception ex) {

        }
    }
}
