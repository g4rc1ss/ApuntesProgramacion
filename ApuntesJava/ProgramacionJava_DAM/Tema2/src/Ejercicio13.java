//13.- Programa que visualice los divisores del número dado por el usuario.
import java.util.Scanner;
public class Ejercicio13 {

	public static void main(String[] args) {
		Scanner teclado=new Scanner(System.in);

		//Variables
		int n1;
		int divisor;
		int aux;
		
		//Codigo
		System.out.println("Teclea un numero:");
			n1=teclado.nextByte();
			
		divisor=n1;
		
		do{
		aux=n1%divisor;
		
		
			if (aux==0){
				System.out.println("El divisor es: "+divisor);
				divisor--;
			}
			else{
				divisor--;
			
				
			}
		}
		while(divisor!=0);
		
		
		
		
		
		
		
		
	
	}
}
