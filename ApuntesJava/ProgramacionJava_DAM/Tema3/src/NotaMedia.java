/* Implementar la clase nota media, teclear en el constructor nombre del alumno y un numero variable de notas. 
 En un metodo llamado obtener nota media visualizar la nota media del alumno*/

import java.util.Scanner;
public class NotaMedia {
	
	
	Scanner teclado=new Scanner (System.in);
	String nombre;
	byte nota;
	byte contador=0;
	char opcion;
	int notaTotal=0;
	
	NotaMedia(){
            System.out.println("Teclea un nombre");
            nombre=teclado.nextLine();
		do{
			
			System.out.println("Teclea una nota");
				nota=teclado.nextByte();
			notaTotal=(notaTotal+nota);
			contador++;
			System.out.println("Vas a seguir metiendo notas? S/N");
				opcion=teclado.next().charAt(0);
		}while(opcion=='S' || opcion == 's');
		}
		void ObtenerNotaMedia(){
			System.out.println("La nota media de "+nombre+" es: "+(notaTotal/contador));
		}
		
	
	
	
		
		
		public static void main(String [] args) {
	
			NotaMedia nM=new NotaMedia();
				nM.ObtenerNotaMedia();
			
			
			
			
	}
}
