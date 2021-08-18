package coches.facturacion;

public class Compra {


	//Atributos
	Vendedor vendedor;
	Coche coche;
	Cliente cliente;
	byte dia,mes;
	short anyo;
	
	//Constructores
	Compra(){
		
	}
	Compra(Vendedor vendedor,Coche coche,Cliente cliente,byte dia,byte mes,short anyo){
		this.vendedor=vendedor;
		this.coche=coche;
		this.cliente=cliente;
		this.dia=dia;
		this.mes=mes;
		this.anyo=anyo;
	}
	
	//Metodos
	void visualizar(){
		System.out.println("El dia: "+dia+" del mes: "+mes+" del año: "+anyo);
		System.out.println("El cliente: "+cliente.getNombre());
		System.out.println("ha comprado el coche: "+coche.getMatricula()+" de la marca: "+coche.getMarca()+" modelo: "+coche.getModelo());
		System.out.println("y su vendedor es: "+vendedor.getNombre());
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
