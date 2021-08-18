import java.util.Scanner;
public class TrabajoSwitch {

	public static void main(String[] args) {
	
Scanner teclado=new Scanner(System.in);
		
		//Variables

		int n1;
		int n2;
		char opciones;
		long resultado = 0;
		//Codigo
		
		System.out.println("S - Sumar");
		System.out.println("R - Restar");
		System.out.println("M - Multiplicar");
		System.out.println("D - Dividir");
		System.out.println("Elige una opción: ");
			opciones=teclado.next().charAt(0);

		
			if(opciones!='S' || opciones!='R' || opciones!='M' || opciones!='D'){
				System.out.println("Elige una de las opciones anteriores, incompetente");
			}
			else{
				
			System.out.println("Escribe un : ");
				n1=teclado.nextInt();
			System.out.println("Escribe el otro :  ");
				n2=teclado.nextInt();
				
				switch(opciones){
				
				case 'S':
					resultado=n1+n2;
					System.out.println("el resultado es: "+resultado);
					break;
				case 'R':
					resultado=n1-n2;
					System.out.println("el resultado es: "+resultado);
					break;	
				case 'M':
					resultado=n1*n2;
					System.out.println("el resultado es: "+resultado);
					break;	
				case 'D':
					resultado=n1/n2;
					System.out.println("el resultado es: "+resultado);
					break;	
				default:
				
				}
			}

		
	}
}

