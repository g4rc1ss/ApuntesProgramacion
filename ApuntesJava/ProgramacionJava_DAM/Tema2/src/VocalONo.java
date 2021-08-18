import java.util.Scanner;
public class VocalONo {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner teclado=new Scanner(System.in);
		
		//Variables
		char letra;
		
		
		
		
		//Codigo
		
		System.out.println("Teclea una letra: ");
			letra=teclado.next().charAt(0);

		
	if(letra=='a'||letra=='e'||letra=='i'||letra=='o'||letra=='u'||letra=='A'||letra=='E'||letra=='I'||letra=='O'||letra=='U'){
		System.out.println("La letra es una vocal.");
}
	else{
		System.out.println("La letra es una consonante.");
}
	}

}
