import java.util.Scanner;
public class Navidad {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner teclado=new Scanner(System.in);
		
			//Variables
		byte dia,mes;
		
			
		
			//Codigo
		System.out.println("Teclea un dia");
			dia=teclado.nextByte();
		System.out.println("Teclea un mes");
			mes=teclado.nextByte();
			
		if (dia==25 && mes ==12){
			
			System.out.println("¡Es navidad!");
		}
		else{
			System.out.println("No es navidad");
		}
		
	}

}
