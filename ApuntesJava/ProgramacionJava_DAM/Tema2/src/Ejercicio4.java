/*4.-Programa que le diga al usuario si el a�o tecleado es o no bisiesto.
Para que un a�o sea bisiesto tiene que ser m�ltiplo de 4, existe una excepci�n: si adem�s de ser m�ltiplo de 4 es tambi�n m�ltiplo de 100 y no es m�ltiplo de 400 no es bisiesto.
A�o 1900 no bisiesto, 2000 si, 2100 no, 1996 si.
Realizar el ejercicio con if simples y tambi�n con if m�ltiples.*/
import java.util.Scanner;

public class Ejercicio4 {

	public static void main(String[] args) {
		Scanner teclado=new Scanner(System.in);

	//Variables
		int n1;
	//Codigo
		System.out.println("Escribe un a�o");
			n1=teclado.nextInt();
		
		if(n1%4==0&&n1%100!=0||n1%400==0){
			System.out.println("El a�o es bisiesto");
		}
		else{
			System.out.println("El a�o no es bisiesto");
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	}

}
