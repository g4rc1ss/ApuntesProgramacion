package Ejercicios;

/*Inicializar un vector con 10 numeros. Con el metodo VerificarOrden comprobar si los numeros est�n ordenados de menor a mayor 
y visualizar "El vector est� ordenado" o "El vector no est� ordenado"*/

public class DictadoArrays2 {

		//Variables
	int[] array = {111,211,311,411,511,611,711,811,911,011};
	boolean sw;
	
		//Codigo	
	DictadoArrays2(){
		
		
	}
	
	void verificarOrden(){
		
		for( byte x=0 ; x<array.length && sw==false ; x++ ){
			
			if( array [x] > array [x+1]){
				sw = true;
			}
			
		}
		
		if(sw == true){
			System.out.println("El vector no est� ordenado");
		}
		else{
			System.out.println("El vector est� ordenado");
		}
		
		
		
		
		
	}
	
	
	
	
	
	
	
	
	
	public static void main(String[] args) {
	
		
		
		
		
		
		
		
		
		
		

	}

}

