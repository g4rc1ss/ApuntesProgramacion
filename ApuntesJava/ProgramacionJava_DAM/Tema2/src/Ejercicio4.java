/*4.-Programa que le diga al usuario si el año tecleado es o no bisiesto.
Para que un año sea bisiesto tiene que ser múltiplo de 4, existe una excepción: si además de ser múltiplo de 4 es también múltiplo de 100 y no es múltiplo de 400 no es bisiesto.
Año 1900 no bisiesto, 2000 si, 2100 no, 1996 si.
Realizar el ejercicio con if simples y también con if múltiples.*/
import java.util.Scanner;

public class Ejercicio4 {

	public static void main(String[] args) {
		Scanner teclado=new Scanner(System.in);

	//Variables
		int n1;
	//Codigo
		System.out.println("Escribe un año");
			n1=teclado.nextInt();
		
		if(n1%4==0&&n1%100!=0||n1%400==0){
			System.out.println("El año es bisiesto");
		}
		else{
			System.out.println("El año no es bisiesto");
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	}

}
