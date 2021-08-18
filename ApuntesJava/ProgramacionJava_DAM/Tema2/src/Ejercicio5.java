/*5.- Teclear 5 datos: n1, n2, n3, n4, n5. El programa debe visualizar:
•	Si los 5 datos son iguales debe visualizar la suma de los 5 datos.
•	Si n1 es igual a n2 y n2es distinto a n3 debe visualizar: n2 no es igual a n3.
•	Si n1 es distinto de n2 y n3 es igual a n4 debe visualizar la suma de n3 y n4.
•	Si n1 es distinto de n2 y n4 es igual a n5 debe visualizar la suma de n4 y n5.
•	El resto de los casos no se hace nada.*/



import java.util.Scanner;
public class Ejercicio5 {

	public static void main(String[] args) {
		Scanner teclado=new Scanner(System.in);

		//Variables
		
			int n1;
			int n2;
			int n3;
			int n4;
			int n5;
			
		//Codigo
			System.out.println("Teclea un número");
				n1=teclado.nextInt();
			System.out.println("Teclea otro número");
				n2=teclado.nextInt();
			System.out.println("Teclea otro número");
				n3=teclado.nextInt();
			System.out.println("Teclea otro número");
				n4=teclado.nextInt();
			System.out.println("Teclea otro número");
				n5=teclado.nextInt();
				
				
				
		if(n1==n2&&n1==n3&&n1==n4&&n1==n5){
			System.out.println("La suma de todos los numeros es: "+(n1+n2+n3+n4+n5));
		}
		else if(n1==n2&&n2!=n3){
			System.out.println("El segundo numero no es igual al tercero");
		}
		else if(n1!=n2&&n3==n4){
			System.out.println("La suma del tercer numero y el cuarto numero es: "+ (n3+n4));
		}
		else if(n1!=n2&&n4==n5){
			System.out.println("La suma del cuarto numero y el quint numero es: "+ (n4+n5));
		}
				
	}

}
