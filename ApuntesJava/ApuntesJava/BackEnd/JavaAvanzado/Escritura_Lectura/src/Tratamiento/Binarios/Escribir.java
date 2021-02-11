package Tratamiento.Binarios;

import java.io.File;
import java.io.IOException;
import java.io.RandomAccessFile;

public class Escribir {

	public boolean setDatos(int[] valores, double[] reales) {
		try {
			File archivo = new File("archivo.dat");//cargamos el archivo
			RandomAccessFile escribir = new RandomAccessFile(archivo, "rw");//creamos la instancia del ficheroAleatorio

			//escribimos mediante un bucle for, los datos del array
			for (int x = 0; x < valores.length; x++) {
				escribir.writeInt(valores[x]);
				escribir.writeDouble(reales[x]);
			}
		} catch (IOException e) {
			return false;
		}
		return true;
	}
	
}