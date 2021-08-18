import java.util.Scanner;
public class Fiesta {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner teclado=new Scanner(System.in);
		
		//Variables
		byte dia,mes;
		boolean sw=false;
		
		//Codigo
		
	System.out.printf("Teclea un día");
		dia=teclado.nextByte();
	System.out.printf("Teclea un mes");
		mes=teclado.nextByte();
		
			if(dia==7 && mes==10){
				sw=true;
			}
			else if(dia==6 && mes==12){
				sw=true;
			}
			if(sw==true){
				System.out.printf("Es fiesta");
			}
			else{
				System.out.printf("No es fiesta");
			}
		
		
		
		
		
		
		
		
		
		
		
		
		
	}

}
