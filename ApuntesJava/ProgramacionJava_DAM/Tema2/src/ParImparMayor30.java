import java.util.Scanner;
public class ParImparMayor30 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner teclado=new Scanner(System.in);
		
		//Variables
		int numero;
		
		
		//Codigo
		
		System.out.println("Teclea un n�mero: ");
			numero=teclado.nextInt();
			
				if(numero%2==0){
					System.out.println("Es un n�mero par");
				}
				else{
					System.out.println("Es un n�mero impar");
				}
				
				if(numero>30){
					System.out.println("Es un n�mero mayor que 30");
				}
				else{
					System.out.println("Es un n�mero menos de 30");
				}
		
		
		
		
		
		
		
		
	}

}
