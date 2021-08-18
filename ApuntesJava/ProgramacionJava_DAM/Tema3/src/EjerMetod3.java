/*
Restar 2 números tipo double.
Los números  se teclean en el constructor.
Métodos:
restar()para realizar la resta
visualizar() para visualizar el resultado.
*/

import java.util.Scanner;
public class EjerMetod3 {
	double resultado;
	double n1;
	double n2;
	Scanner teclado=new Scanner(System.in);
 EjerMetod3(){
	
	System.out.println("Teclea un numero de tipo double");
		n1=teclado.nextDouble();
	System.out.println("Teclea un segundo numero double");
		n2=teclado.nextDouble();

}

void restar(){
	
	resultado=n1-n2;
	
}
	
void visualizar(){
	
	System.out.println("El resultado es: "+resultado);

}
	

public static void main(String[] args) {
		
	EjerMetod3 Ejer=new EjerMetod3();		
		
	Ejer.restar();
	Ejer.visualizar();
	
	
	}

}
