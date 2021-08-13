package Tratamiento.EscribirBytes;

import java.io.*;

public class EscribirLeerBytes {
	public static void main(String[] args) throws IOException {
		
		File fichero = new File("FichBytesPrim.dat");
		
		FileOutputStream fileout = new FileOutputStream(fichero);
		DataOutputStream dataout = new DataOutputStream(fileout);
		
		FileInputStream filein = new FileInputStream(fichero);	
		DataInputStream datain = new DataInputStream(filein);
		
		String nombres [] = {"Ricardo","Endika", "Andoni"};
		int edades [] = {20,21,22};

		for (int i = 0; i < nombres.length; i++) {
			dataout.writeUTF(nombres[i]);
			dataout.writeInt(edades[i]);
		}
		dataout.close();

		try {
			while (true) {
				System.out.println("Nombre: " + datain.readUTF() + ", Edad: "+ datain.readInt());
			}
		} catch (EOFException eo) {
			System.out.println("Fin del fichero");
		}
		datain.close();
		
	}
}
