package ventas.vendedor;
/*Clase ventas
Los atributos son nombre del articulo vendido, cantidad y precio. El constructor recibe los 3 parametros.
Metodo ver: visualiza nombre del articulo, cantidad, precio y el importe (precio x cantidad).
Metodo ganancia: retorna precio x cantidad.*/
public class Ventas {

	String nombreArticulo;
	int cantidad;
	float precio;

	
	Ventas(String nombreArticulo, int cantidad, float precio){
		
		this.nombreArticulo=nombreArticulo;
		this.cantidad=cantidad;
		this.precio=precio;
		
	}
	void ver(){
		
		System.out.println("------------------------------------------");
		System.out.println("El nombre del articulo es: "+nombreArticulo);
		System.out.println("La cantidad comprada del articulo es: "+cantidad);
		System.out.println("El precio del articulo es: "+precio);
		System.out.println("El importe del articulo es: "+cantidad*precio);
		
		
	}
	float ganancia(){
		
		return precio*cantidad;
		
	}
	
	
	
	
	
	
	
	
	
	
}


