package ventas.vendedor;

public class Principal {
	/*
	 El package va a ser ventas.vendedor.
	 Clase principal: crear una instancia de vendedor. Llamar al metodo nuevas ventas y llamar al metodo ver de vendedor.
	*/
	public static void main(String[] args) {
		
		boolean b;
		
		Vendedor vend = new Vendedor("Juan",3);

		Ventas  [ ] venta = { new Ventas("tuercas",14,4),new Ventas ("tuercas",100,8)};
				
		b = vend.nuevasVentas( venta );
		
		if( b == true){
			
			vend.ver( );
			
		}	
		
	}

}
