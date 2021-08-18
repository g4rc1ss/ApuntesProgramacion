
/*Teclear nombre y edad de dos personas, visualizar el nombre de la persona de mayor edad y si son de la misma edad visualizar el 
 nombre de las dos personas */

import java.util.Scanner;  

public class EjercicioDictado {

	public static void main(String[] args) {
		Scanner teclado=new Scanner(System.in);

	//Variables
		
		String nombre1,nombre2;
		byte edad1,edad2;
		
	//Codigo
		
			System.out.println("Teclea el nombre de la primera persona: ");
				nombre1=teclado.nextLine();
			System.out.println("Teclea el nombre de la segunda persona: ");
				nombre2=teclado.nextLine();
			System.out.println("Teclea la edad de la primera persona: ");
				edad1=teclado.nextByte();
			System.out.println("Teclea la edad de la segunda persona");
				edad2=teclado.nextByte();
			
		if(edad1>edad2){
			System.out.println(nombre1+" es mas mayor que "+nombre2+" porque "+nombre1+" tiene "+edad1+" años y "+nombre2+" tiene "+edad2+" años.");
		}
		else if(edad1==edad2){
			System.out.println(nombre1+" es mas igual de mayor que "+nombre2+" porque "+nombre1+" tiene "+edad1+" años y "+nombre2+" tiene "+edad2+" años.");
		}
		else{
			System.out.println(nombre1+" es mas joven que "+nombre2+" porque "+nombre1+" tiene "+edad1+" años y "+nombre2+" tiene "+edad2+" años.");
		}
		
		
		
		
		
		
		
		

	}

}
