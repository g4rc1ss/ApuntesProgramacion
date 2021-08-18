
import java.util.Scanner;

	public class Persona {
	Scanner teclado = new Scanner (System.in);

	String nombre;
	byte edad;
	
	void setDatos(){
		System.out.println("Teclea tu edad");
		edad=teclado.nextByte();
		System.out.println("Teclea tu nombre");
		nombre=teclado.nextLine();
	}
	void getDatos(){
		System.out.println("Edad: "+edad);
		System.out.println("Nombre: "+nombre);
	}
	void mayorEdad(){
		if (edad >= 28){
			System.out.println("Es mayor de edad");
		}
		else{
			System.out.println("Es menor de edad");
		}
	}
	
public static void main(String[] args) {
	Persona p=new Persona();
		p.setDatos();
		p.getDatos();
		p.mayorEdad();
	}

}
