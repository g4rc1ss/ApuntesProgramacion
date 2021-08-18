import java.util.Scanner;
public class Factorial {

	public static void main(String[] args) {
		Scanner teclado=new Scanner(System.in);
		
			//Variables
				byte n;
				long factorial=1;
				byte aux;
		
			//Código

				do{
					System.out.println("Teclea un número");
					n=teclado.nextByte();
				}while(n<0);
				
				aux=n;
				
				while(n>0){
					factorial=factorial*n;
					n--;
				}
				System.out.println("El factorial de "+aux+" es "+factorial);
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	}

}
