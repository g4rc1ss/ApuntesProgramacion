//Teclear 3 numeros, si los 3 numeros son menores que 10 visualizar "todos los numeros son menores a 10"
import java.util.Scanner;
public class Numeros {

	public static void main(String[] args) {
		Scanner teclado=new Scanner(System.in);
		//Variables
			byte n1;
			byte n2;
			byte n3;
		//Codigo
			
		System.out.println("Teclea un n�mero");
			n1=teclado.nextByte();
		System.out.println("Teclea un segundo n�mero");
			n2=teclado.nextByte();
		System.out.println("Teclea un tercer n�mero");
			n3=teclado.nextByte();
			
			if(n1<10 && n2<10 && n3<10){
				System.out.println("Todos los n�meros son menos que 10");
			}
			
			if(n1<10||n2<10||n3<10){
				System.out.println("Alguno de los n�meros es menor que 10");
			}
			
	
	
	}
}
