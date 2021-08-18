import java.util.Scanner;
public class Ejercicio10 {

	public static void main(String[] args) {
		Scanner teclado= new Scanner(System.in);

	//VARIABLES
		
		float nota;
		
	//CODIGO
		
		System.out.println("Teclea tu nota:");
			nota=teclado.nextFloat();
		
		if(nota>=0 && nota<=5.9){
			System.out.println("Tu nota es una F, deberias ir pensando en trabajar en un Burger King");
		}
		else if(nota>5.9 && nota<=6.9){
			System.out.println("Tu nota es una D, has aprobado, pero deberías esforzarte bastante mas");
		}
		else if(nota>6.9 && nota<=7.4){
			System.out.println("Tu nota es una C, has aprobado, pero deberías esforzarte mas");
		}
		else if(nota>7.4 && nota<=7.9){
			System.out.println("Tu nota es una C+, no está mal, pero no debes relajarte demasiado");
		}
		else if(nota>7.9 && nota<=8.4){
			System.out.println("Tu nota es una B, vas bien");
		}
		else if(nota>8.4 && nota<=8.9){
			System.out.println("Tu nota es una B+, vas muy bien");	
		}	
		else if(nota>8.9 && nota<=10){
			System.out.println("Tu nota es una A, deja de copiar");
		
		}
		
	}

}
