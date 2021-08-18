package ventas.vendedor;
/*
Clase vendedor, atributos: array ventas. 
El constructor recibe nombre y el maximo de ventas que puede realizar ese vendedor, es decir la dimension del array.
Metodo nuevas ventas. Recibe un array de nuevas ventas. Controlar que no se exceda del tamaño del array. 
En dicho caso visualizar un mensaje y terminar programa. El metodo retornará a false en este caso
Visualiza nombre del vendedor y llamara al metodo ver de ventas para obtener el nombre del articulo, cantidad e importe.
*/
public class Vendedor {

	Ventas [ ] v;
	String nombre;
	
	
	Vendedor(String nombre, int dimension){
		
		this.nombre=nombre;

		v = new Ventas [dimension];
		
		
	}
	
	boolean nuevasVentas( Ventas [] v ){
		
		if(v.length > this.v.length){
			System.out.println("ERROR");
			
			return false;
		}
		else{
			
			this.v=v;
			
			return true;
			
		}
		
	}
	
	void ver(  ){
		
		System.out.println("El vendedor se llama: "+nombre);
		
		
		
		for(int x = 0; x<v.length; x++ ){
			
			v[ x ].ver();
			
		}
		
	}
	
	
	
	
	
	
	
	
	
	
	
	
}
