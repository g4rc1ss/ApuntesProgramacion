package alumnos;
public class Colegio {

		//Variables
	String codigo, nombre, web;
	int telefono;

		//Codigo
	
	Colegio(String codigo,String nombre,String web, int telefono){
		this.codigo=codigo;
		this.nombre=nombre;
		this.web=web;
		this.telefono=telefono;
		
		
	}


	void altaTelefono(){
		
	}

	String getNombre(String nombre){
		this.nombre=nombre;
		
		return nombre;
	}

	int getTelefono(int telefono){
		this.telefono=telefono;
		
		return telefono;
	}

















}

