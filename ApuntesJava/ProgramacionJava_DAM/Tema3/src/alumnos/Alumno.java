package alumnos;

public class Alumno {

		//Variables
	int numero,telefono;
	String nombre;
	Colegio colegio;
	
		//Codigo
	
	Alumno(int numero, int telefono,String nombre, String colegio){
		this.numero=numero;
		this.telefono=telefono;
		this.nombre=nombre;
	
	}
	
	void cambiarTelefono(int telefono){
		this.telefono=telefono;
	}
	
	void visualizar(){
		
		System.out.println("El alumno: "+nombre+"con teléfono: "+telefono);
		System.out.println("Estudia en el colegio: ");
		System.out.println("Telefono del colegio: ");
	
	
	
	
	
	
}
}
