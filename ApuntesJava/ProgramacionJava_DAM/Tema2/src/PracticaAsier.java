import java.util.Scanner;
public class PracticaAsier {

	public static void main(String[] args) {
		
		Scanner teclado=new Scanner(System.in);
		
		//Variables
		String nombre;
		byte dato1,dato2;	
		
		//Codigo restante
		
		System.out.println("Vamos a empezar con el nombre: ");
			nombre=teclado.nextLine();
		System.out.println("Me tienes que decir un número del -127 al +126: ");
			dato1=teclado.nextByte();
		System.out.println("Ahora me tienes que decir otra del mismo rango");
			dato2=teclado.nextByte();
		System.out.println("Muchas gracias, procedemos a la compración");
		
			if(dato1>dato2){
				System.out.println(dato1+" Es mayor que "+dato2);
			}
			else if(dato1==dato2){
				System.out.println("Los dos datos son iguales, no tiene gracia ;(");
			}
			else{
				System.out.println(dato1+" Es menor que 5 "+dato2);
			}
			
			
		System.out.println("Muchas gracias "+nombre);
	}

}

































/*Teclear nombre y edad de dos personas, visualizar el nombre de la persona de mayor edad y si son de la misma edad visualizar el 
 nombre de las dos personas */