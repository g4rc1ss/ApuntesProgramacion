//1.- Teclear un n�mero, queremos que el programa visualice: nulo, negativo o positivo, seg�n el n�mero tecleado.

import java.util.Scanner;

public class Ejercicio1 {

	public static void main(String[] args) {
	Scanner teclado=new Scanner (System.in);
		//Variables
	
	byte n1;
	
	
	
		//Codigo
		
	System.out.println("Teclea un numero:");
		n1=teclado.nextByte();
	
		if(n1>0){
			System.out.println("El numero es positivo");
		}
		else if (n1<0){
			System.out.println("El numero es negativo");	
		}
		else{
			System.out.println("El numero es nulo");
		}
		
		
		
		
		
		
		
		
		
		
	}

}
