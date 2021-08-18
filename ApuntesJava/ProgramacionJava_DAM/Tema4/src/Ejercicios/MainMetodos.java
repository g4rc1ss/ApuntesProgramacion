package Ejercicios;

import java.util.Scanner;

public class MainMetodos {

	public static void main(String[] args) {
		Scanner teclado=new Scanner(System.in);

		//Variables
	int n;
		
		//Codigo
	
	System.out.println("Teclea el numero de elementos que tiene el array: ");
		n=teclado.nextInt();
		
		
		Metodos metod=new Metodos(n);
		
			metod.teclear();
			
			
	}

}
