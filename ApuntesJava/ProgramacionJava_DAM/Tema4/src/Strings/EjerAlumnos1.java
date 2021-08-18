/*1.Realizar una clase, que permita teclear una dirección de mail en el constructor, 
luego en otro método mostrar un mensaje si contiene el caracter '@'. */
package Strings;
import java.util.Scanner;
public class EjerAlumnos1 {
Scanner teclado=new Scanner(System.in);

String email;

int verificar;

EjerAlumnos1(){
	
	System.out.println("Teclea un email: ");
	email=teclado.nextLine( );
	
}

void tenerArroba(){
	
	verificar=email.indexOf("@");
	
	if (verificar!=-1){
		
		System.out.println("Este e-mail tiene un @");
		
	}
	else{
		System.out.println("Este e-mail no tiene un @");
	}
	
}

	public static void main(String[] args) {
	
		
		
		
		
	}

}
