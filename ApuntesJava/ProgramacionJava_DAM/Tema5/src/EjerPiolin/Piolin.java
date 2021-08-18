package EjerPiolin;


class Ave { //primera clase de todos y la superclase de todas las restantes
	
				//Atributos de instancia
	
	 char sexo;
	
	 byte edad;
	
	 static int numeroAves;
	
				//Metodos...
	
	public Ave( char sexo, byte edad  ) { //Inicio del contructor de ave, es public
		
		this.sexo = sexo;
		
		this.edad = edad;
		
			numeroAves ++;
		
	}//Fin del constructor
	
	private void visNumAves(  ) {
		
		System.out.println( "El número de aves que hay son: " + numeroAves );
		
	}
	
	 void quienSoy(  ) {
		
		System.out.println( "La edad del ave es:" + edad + "El sexo es: " + sexo );
		
	}

}//Fin de la clase Ave


 //---------------------------------------------------------------------------------------------------------------------------------------------\\
//-----------------------------------------------------------------------------------------------------------------------------------------------\\


class Canario extends Ave { //Subclase de Ave y Superclase de Piolin
	
				//Atributos de instancia
	
	 float tamanio;
	
				//Metodos...
	
	public Canario( char sexo,byte edad, float tamanio ) { //inicio de constructor
		
		super( sexo, edad );
		
		this.tamanio = tamanio;
		
	}//Fin de constructor
	
	public Canario( char sexo, byte edad ) {
		
		super( sexo, edad );
		
		this.sexo = sexo;
		
		this.edad = edad;
		
	}
	
	void altura(  ) {
		
		if( tamanio > 30 ) {
			
			System.out.println("ALTO");
			
		}
		
		else if( tamanio < 30 && tamanio > 15 ) {
			
			System.out.println("MEDIANO");
			
		}
		
		else {
			
			System.out.println("BAJO");
			
		}
		
	} //Fin de constructor
	
}


 //---------------------------------------------------------------------------------------------------------------------------------------------\\
//-----------------------------------------------------------------------------------------------------------------------------------------------\\


class Loro extends Ave { //Subclase de Ave
	
						//Atributos de instancia
	
	String color;
	
	char region;
	
						//Metodos...
	
	public Loro( char sexo, byte edad, char region, String color ){//Inicio del contructor
		
		super( sexo, edad );
		
		this.sexo = sexo;
		
		this.color = color;
		
		this.region = region;
		
		this.edad = edad;
		
	}//Fin del constructor
	
	void deDondeEres(  ) {
		
		switch( region ) {
		
			case 'O':
				
				System.out.println("OESTE");
				
			break;
			
			case 'M':
				
				System.out.println("NORTE");
				
			break;
			
			case 'S':
				
				System.out.println("SUR");
				
			break;
			
			case 'E':
				
				System.out.println("ESTE");
			
			break;
		
		}//Fin del switch
		
	}//Fin del metodo deDondeEres
	
}//Fin de la class


 //---------------------------------------------------------------------------------------------------------------------------------------------\\
//-----------------------------------------------------------------------------------------------------------------------------------------------\\


public class Piolin extends Canario { //Subclase de Canario y por tanto Subclase de Ave
	
					//Atributos de instancia
	
		int numPeliculas;
	
					//Metodos
	
	public Piolin( char sexo, byte edad, float tamanio, int numPeliculas ) {
		
		super( sexo, edad, tamanio );
		
		this.numPeliculas = numPeliculas;
		
		
	}//fin de constructor
	
	public static void main ( String[  ] args ) {
		
		Piolin pio = new Piolin( 'M', (byte) 20, 1.75F, 7 );
		
		Loro lor = new Loro( 'H', (byte) 5, 'N', "blanco" );
		
		//---------------------------------------------------------------------------------\\
		
		pio.quienSoy(  );
		
		lor.quienSoy(  );
		
		pio.altura();
		
		lor.deDondeEres();
		
		pio.tamanio = 30.00F;
		
		pio.altura();
		
		lor.region = 'S';
		
		System.out.println(numeroAves);
		
	}
	
}