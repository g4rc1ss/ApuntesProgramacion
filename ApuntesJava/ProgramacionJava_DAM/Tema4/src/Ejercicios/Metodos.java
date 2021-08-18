	/* En el metodo main se deben teclear los numeros que se deben teclear en el ejercicio. El constructor recibe la cantidad mencionada anteriormente.
	Metodo teclear: Syso teclea x numeros y teclear tantos numeos como se haya indicado en el metodo main. 
	Metodo visualizar: visualizar los numeros tecleados.*/
package Ejercicios;
import java.util.Scanner;
public class Metodos {
	Scanner teclado=new Scanner( System.in );
	
	
		//Array y variable
	int[]num;
	int n;
	
	
	Metodos(int n){
		
		num = new int [n];
		this.n=n;
		
	}
	
	void teclear(){
		
		System.out.println( "Teclea "+n+" numeros en total");
		
		
		/*La "x" del for es la posicion que lleva en la tabla, empieza desde la celda 0 (por el x=0), 
		 rellenamos esa celda y pasamos a rellenar la siguiente*/
			for( int x=0;x<n;x++ ){ 
			
				num[x]=teclado.nextInt();
			
			}
		
		visualizar();
	}
	
	void visualizar(){
		
		for( int x=0;x<n;x++ ){
			
			System.out.println("Los numeros tecleados son: "+num[x]);
		}
		
	}
	
}
