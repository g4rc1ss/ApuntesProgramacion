package Arrays;
import java.util.Scanner;
public class Arrays {
	Scanner teclado=new Scanner(System.in);
	
	
	
	//Array
	int[]n=new int[5];
	
	
	//Constructor
	void teclear(){
		for(int x=0;x<5;x++){
		
		System.out.println("Teclea un numero: ");
			n[x]=teclado.nextInt();
		}
		
	}
	
	//Syso
	void visualizar(){
		
		for(int x=0;x<5;x++){
			System.out.println(n[x]);
		}
	}
	
	
	
	
	
	
	
	
	
	
	
	
}
