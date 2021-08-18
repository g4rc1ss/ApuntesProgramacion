package Ejercicios;
import java.util.Scanner;
public class DictadoArrays {
	Scanner teclado=new Scanner(System.in);
	
	/*Crear dos arrays de tipo float que van a contener el sueldo de 4 empleados del turno de mañana y el sueldo de otros 4 del turno de tarde
	 Metodo teclear (Syso para teclear sueldos y for para hacerlo)
	 Metodo visualizar (con un unico for: visualizar todos los sueldos)*/
	
	
	//VARIABLES
		float [] sueldo= {1.2F,1.2F,1.2F,1.2F,2.1F,2.1F,2.1F,2.1F};
		
		
	
	//CODIGO
		DictadoArrays(){
			
		}
	
		void teclear(){
			
			System.out.println("Teclea el sueldo de cada uno de los 4 empleados de la mañana y a continuación los de los 4 empleados de la tarde: ");
			
			for(int x=0;x<8;x++){
				sueldo[x]=teclado.nextInt();
			}
			
			
		}
		void visualizar(){
			
			for(int x=0;x<4;x++){
				System.out.println("Los sueldos de los empleados de la mañana son: "+sueldo[x]);
			}
			
			for(int x=4;x<8;x++){
				System.out.println("Los sueldos de los empleados de la tarde son: "+sueldo[x]);
			}
		}
		
		
		float totalSueldos(){
			float suma=0;
			
			
			for(int x=0;x<sueldo.length;x++){
				
				suma+=sueldo[x];
			
			}
			
			return suma;						
		}
		
		void visualizarSueldoTotal( float suma ){
			
			System.out.println("---------------------------------------");
			
			System.out.println("La suma de todos los sueldos es: "+suma);
		}
		
		

		
	public static void main(String[] args) {
		
		float suma;
			DictadoArrays dic=new DictadoArrays();
			
		// dic.teclear();
		dic.visualizar();
		suma = dic.totalSueldos();
		
		dic.visualizarSueldoTotal(suma);
	}

}
/*En vez de crear 2 arrays de 4 elementos, crear 1 array de 8 elementos. Los 4 primeros sueldos son los del turno de mañana y el resto son del turno de tarde.
 Metodo visualizar y hay que visualizar sueldo turno mañana y los 4 de la mañana, y lo mismo para la tarde*/
 




