package Tratamiento.ArchivosTexto;

import java.io.File;
import java.io.FileReader;
import java.io.IOException;

public class LeerFicheroTexto {

  public static void main(String[] args) throws IOException {
    File fichero = new File("FichTexto_escritura.txt");
    FileReader fic = new FileReader(fichero);

    char b[]= new char[60]; // numero de caracteres
    while ((fic.read(b)) != -1)
		System.out.println(b);
    fic.close(); //cerrar fichero
  }
}