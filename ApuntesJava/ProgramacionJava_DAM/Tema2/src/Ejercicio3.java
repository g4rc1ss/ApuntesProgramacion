/*3.-Programa que pida al usuario 3 n�meros y visualice el mensaje:�son iguales� si la suma de dos de ellos es igual al otro n�mero 
y si no se visualizar� �no son iguales�.*/
import java.util.Scanner;

public class Ejercicio3 {

	public static void main(String[] args) {
	Scanner teclado=new Scanner (System.in);

		//Variables
			byte n1;
			byte n2;
			byte n3;
		
		//Codigo
			System.out.println("Teclea un n�mero:");
				n1=teclado.nextByte();
			System.out.println("Teclea otro n�mero:");
				n2=teclado.nextByte();
			System.out.println("Teclea otro n�mero:");
				n3=teclado.nextByte();
		
		if(n1+n2==n3||n1+n3==n2||n2+n3==n1){
			System.out.println("La suma de los dos primeros numeros es igual al tercero");
		}
		else{
			System.out.println("La suma de los dos primeros numeros no es igual al tercero");
		}
		
		
		
		
		
		
		
		
		

	}

}
