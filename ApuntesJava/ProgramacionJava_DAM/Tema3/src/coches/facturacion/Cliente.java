package coches.facturacion;

public class Cliente {

		//Atributos
	String dni,nombre,provincia;
	int telefono;
	
		//Constructores
	Cliente(){
		
	}
	Cliente(String dni,String nombre,String provincia,int telefono){
		this.dni=dni;
		this.nombre=nombre;
		this.provincia=provincia;
		this.telefono=telefono;
	}
	Cliente(int telefono){
		this.telefono=telefono;
	}

	
		//Getters y Setters
	
	
	public String getDni() {
		return dni;
	}
	public void setDni(String dni) {
		this.dni = dni;
	}
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	public String getProvincia() {
		return provincia;
	}
	public void setProvincia(String provincia) {
		this.provincia = provincia;
	}
	public int getTelefono() {
		return telefono;
	}
	public void setTelefono(int telefono) {
		this.telefono = telefono;
	}
	
	
	
	
	
}
