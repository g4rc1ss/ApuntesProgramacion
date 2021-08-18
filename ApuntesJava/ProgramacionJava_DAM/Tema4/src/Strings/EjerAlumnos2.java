/*
 
2. Teclear un String por teclado e implementar los siguientes métodos:
a) Imprimir la primera mitad de los caracteres de la cadena. 
b) Imprimir el último caracter. 
c) Imprimirlo en forma inversa. 
d) Imprimir cada caracter del String separado con un guión. 
e) Imprimir la cantidad de vocales almacenadas. 
f) Implementar un método que verifique si la cadena se lee igual de izquierda a derecha tanto como de derecha a izquierda (ej. neuquen se lee igual en las dos direcciones) 

 */
package Strings;
import java.util.Scanner;

public class EjerAlumnos2 {
	Scanner teclado=new Scanner(System.in);
	
	String teclear;
	int caracteres;
	
	EjerAlumnos2(){
		System.out.println("Teclea algo: ");
		teclear=teclado.nextLine( );
	}
	
	void a(){
		
		caracteres=teclear.length();
		caracteres = caracteres/2;
		System.out.println(teclear.substring( 0, caracteres));
	}
	void b(){
		caracteres=teclear.length();
		System.out.println(teclear.charAt(caracteres-1));
	}
	void c(){
		
	}
	void d(){
	
	}
	void e(){
	
	}
	void f(){
	
	}
	














}
