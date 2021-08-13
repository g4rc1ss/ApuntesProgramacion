package Tratamiento.Objeto;

import java.io.*;

public class EscribirLeerObjeto {
	public static void main(String[] args) throws IOException, ClassNotFoundException {
		Persona persona;
		File fichero = new File("FichBytesObject.dat");

		FileOutputStream fileout = new FileOutputStream(fichero);
		ObjectOutputStream objout = new ObjectOutputStream(fileout);
		
		FileInputStream filein = new FileInputStream(fichero);	
		ObjectInputStream objin = new ObjectInputStream(filein);
		
		String nombres [] = {"Ricardo","Endika", "Andoni"};
		int edades [] = {20,21,22};
		
		for (int i = 0; i < edades.length; i++) {
			persona = new Persona(nombres[i], edades[i]);
			objout.writeObject(persona);
		}
		objout.close();
		
		try {
			while (true) {
				persona = (Persona) objin.readObject();
				System.out.println(persona.toString());
			}
		} catch (EOFException eo) {
			System.out.println("Fin del fichero");
		}
		objin.close();
	}
}
