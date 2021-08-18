/*2.- Teclear 3 cantidades. 
•	 Si la primera es mayor que la segunda. Visualizar el resultado de la suma de la primera cantidad con la segunda cantidad.
•	Si la primera es menor o igual que la segunda. Visualizar el resultado de restar dichas cantidades.
•	Su producto si la segunda es mayor que la tercera.
•	Su cociente si la segunda es menor o igual que la tercera.*/

import java.util.Scanner;

public class Ejercicio2 {

	public static void main(String[] args) {
	Scanner teclado=new Scanner(System.in);

		//Variables
			int n1;
			int n2;
			int n3;
	
		//Codigo
			System.out.println("Teclea un numero");
				n1=teclado.nextInt();
			System.out.println("Teclea otro numero");
				n2=teclado.nextInt();
			System.out.println("Teclea otro numero");
				n3=teclado.nextInt();
	
			if(n1>n2){
				n1=n1+n2;
				System.out.println("El resultado de la suma es: "+ n1);
			}
			else{
				n1=n1+n2;
				System.out.println("El resultado de la resta es: "+ n1);
			}
			if (n2>n3){
				n1=n2*n3;
				System.out.println("El resultado de la multiplicacion es: "+ n1);
			}
			else{
				n1=n2/n3;
				System.out.println("El resultado de la division es: "+ n1);
			}
	
	
	
	
	
	
	
	
	
	
	}

}
