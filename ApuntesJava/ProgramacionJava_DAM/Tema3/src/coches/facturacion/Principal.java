package coches.facturacion;

public class Principal {

	public static void main(String[] args) {
		
	float importe;	
		
		Vendedor vendedor1=new Vendedor("31321321F","Pedro",(byte) 18,177.213F);
		
		Vendedor vendedor2=new Vendedor("65875876F","Juan",(byte) 1,50.213F);
		
			vendedor1.visualizar();
		
			vendedor2.visualizar();
		
		
		
		Coche coche1=new Coche("321421fd","audi","A4",2323232.2323F);
		
		Coche coche2=new Coche("121421fd","ford","A4",45454532.2323F);
		
		Coche coche3=new Coche("221421fd","pepe","A4",67677676.2323F);
		
		Coche coche4=new Coche("421421fd","lala","A4",89989898.2323F);
		
		Coche coche5=new Coche("521421fd","flurflirls","A4",1414144.2323F);
		
			importe=coche1.precioColor("rojo");
		
			coche1.Visualizar(importe);
			
			importe=coche1.precioColor("azul");
		
			coche2.Visualizar(importe);
			
			importe=coche1.precioColor("marron");
		
			coche3.Visualizar(importe);
			
			importe=coche1.precioColor("morado");
		
			coche4.Visualizar(importe);
			
			importe=coche1.precioColor("verde");
		
			coche5.Visualizar(importe);
		
		Cliente cliente1=new Cliente("qewdqw1","Yo","dfaf",89098);
		
		Cliente cliente2=new Cliente("qewdqw1","Yo","dfaf",5645645);
		
		Cliente cliente3=new Cliente("qewdqw1","Yo","dfaf",2314234);
	}

}
