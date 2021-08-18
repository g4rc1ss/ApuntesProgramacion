package coches.facturacion;
public class Vendedor{
	
		//Atributo de instancia

String dni, nombre;
byte categoria;
float sueldoBase;

		//Constructores

	Vendedor(){
		
	}
	Vendedor(String dni,String nombre,byte categoria,float sueldoBase){
		this.dni=dni;
		this.nombre=nombre;
		this.categoria=categoria;
		this.sueldoBase=sueldoBase;
	}
	Vendedor(byte categoria){
		this.categoria=categoria;
		
	}
	Vendedor(float sueldoBase){
		this.sueldoBase=sueldoBase;
	}
	
		//Metodos
	
	void calculoSueldo(){
	
		if(categoria==1){
			System.out.println(sueldoBase*1.02);
		}
		else{
			System.out.println(sueldoBase*1.05);
		}
	}
	
	
	
	void visualizar(){
		System.out.print("El empleado: "+nombre+" tiene un sueldo de: ");
		calculoSueldo();
	}
	
	
	
	public String getNombre() {
		return nombre;
	}
	public void setNombre(String nombre) {
		this.nombre = nombre;
	}
	
	
}