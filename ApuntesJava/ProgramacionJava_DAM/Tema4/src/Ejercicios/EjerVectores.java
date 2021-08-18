package Ejercicios;
import java.util.Scanner;
public class EjerVectores {
	
	Scanner teclado=new Scanner (System.in);
	float [ ] n = new float [5];
	
	EjerVectores(){
		
		
		
		
	}
	
	void teclear(){
		
		for(int nAlt=0; nAlt<=5; nAlt++){
			
			System.out.println("Teclea 5 alturas");
			n [ nAlt ]=teclado.nextFloat();
			
		}
		
		
	}
	
	float calcularPromedio(){
		
		float suma = 0;
		float rdo;
		
		for(int indice=0; indice<5; indice++){
		
			suma=suma+n [indice];
			
		}
		rdo=suma/5;
		
		return rdo;
	}
	
	void visualizar( float rdo){
		
		System.out.println("La media de la alturas es: "+rdo);
		
	}
	
	void mayorMenor(float rdo){
		
		//VARIABLES
			int cont=0;
			int contAlt=0;
			int contBaj=0;
			
		for(;;){
			
			for( ; contAlt>rdo;contAlt++){
				
			}
			for( ; contBaj<rdo;contBaj++){
				
			}
			
			
			
		}
		
		
		
		
		
		
		
	}
}
	
	
	
	
	
	
	
	
	
	
	
	
	

