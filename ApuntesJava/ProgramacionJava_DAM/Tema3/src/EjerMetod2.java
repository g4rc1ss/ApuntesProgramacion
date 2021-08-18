/*
Restar 2 números tipo byte.
Los números  se teclean en el método setDatos(),
restar()para realizar la resta
visualizar() para visualizar el resultado.
 * */
import java.util.Scanner;
public class EjerMetod2 {
	byte resultado;
	byte n1=1;
	byte n2=5;
	Scanner teclado=new Scanner(System.in);
void setDatos(){
	
	System.out.println("Teclea un numero de tipo byte");
		n1=teclado.nextByte();
	System.out.println("Teclea un segundo numero byte");
		n2=teclado.nextByte();

}

void restar(){
	
	resultado=(byte) (n1-n2);
	
}
	
void visualizar(){
	
	System.out.println("El resultado es: "+resultado);

}
	

public static void main(String[] args) {
		
	EjerMetod2 Ejer=new EjerMetod2();		
		
	Ejer.setDatos();
	Ejer.restar();
	Ejer.visualizar();
				
	}

}
