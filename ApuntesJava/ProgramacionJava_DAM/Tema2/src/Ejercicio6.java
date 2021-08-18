//6.- En Eroski se hace un 20% de descuento a los clientes cuya compra supere los 300€. ¿Cuál será la cantidad que pagará una persona por su compra?.
import java.util.Scanner;

public class Ejercicio6 {

	public static void main(String[] args) {
		Scanner teclado=new Scanner(System.in);

		//Variables
		int n1;
		
		//Codigo
		System.out.println("Teclea un numero");
			n1=teclado.nextInt();
		
		if(n1>300){
			System.out.println("El cliente deberá pagar: "+(n1-((n1*20)/100)));
		}
		else{
			System.out.println("El cliente deberá pagar: "+n1);
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	}

}
