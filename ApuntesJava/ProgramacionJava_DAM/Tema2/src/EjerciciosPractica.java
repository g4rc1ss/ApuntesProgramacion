import java.util.Scanner;
public class EjerciciosPractica {

	public static void main(String[] args) {
		Scanner teclado=new Scanner(System.in);
		
		//Variables
			int n1,n2;
				
		//Codigo
		
			System.out.println("Teclea un número:");
			n1=teclado.nextInt();
			System.out.println("Teclea otro número:");
			n2=teclado.nextInt();
			System.out.println("La suma de dichos números es: "+(n1+n2));
			System.out.println("El producto de dichos números es: "+(n1*n2));
			if(n1>n2){
				System.out.println(n1+" es mayor que "+n2);
		}
		
			else if(n1==n2){
				System.out.println("Ambos números son iguales.");
		}
			else{
				System.out.println(n1+" es menor que "+n2);
		}
			
	}

}
