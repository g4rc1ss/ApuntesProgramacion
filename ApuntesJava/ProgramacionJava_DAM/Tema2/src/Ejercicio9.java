/*9.-Programa que pida al usuario un número entre el 1 y el 10 y visualice la serie de números a partir de él hasta 10.
Realizar el ejercicio con switch().
Por ejemplo teclea 7 y se tiene que visualizar 7,8,9,10.*/

import java.util.Scanner;
public class Ejercicio9 {

	public static void main(String[] args) {
		Scanner teclado=new Scanner(System.in);

		//Variables
	byte num;
	
		//Codigo
	System.out.println("Teclea un numero del 1 al 10");
		num=teclado.nextByte();
		
		
		switch(num){
			case 1: System.out.print("1, ");
				
		
			case 2: System.out.print("2, ");
		
				
				
			case 3: System.out.print("3, ");
				
				
		
			case 4: System.out.print("4, ");
				
				
		
			case 5: System.out.print("5, ");
		
				
				
			case 6: System.out.print("6, ");
				
				
			
			case 7: System.out.print("7, ");
				
				
		
			case 8: System.out.print("8, ");
		
				
				
			case 9: System.out.print("9, ");
				
				
			case 10: System.out.print("10.");	
				
				
		
				
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	}

}
