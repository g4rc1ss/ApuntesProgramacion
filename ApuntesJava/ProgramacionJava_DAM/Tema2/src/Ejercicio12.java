
/*12.- De la galería de productos, el usuario introducirá el código y el número de unidades del 
producto que desea comprar. El programa determinará el total a pagar, como una factura.*/
import java.util.Scanner;
public class Ejercicio12 {

	public static void main(String[] args) {
		Scanner teclado=new Scanner(System.in);
	//Variables
		
		byte cantidad;
		byte producto;
		int precioT;
		
		
	//Codigo
		System.out.println("Producto		Codigo			Precio");
		System.out.println();
		System.out.println("Camisa			1			10€");
		System.out.println("Cinturon		2			15€");
		System.out.println("Zapatos			3			20€");
		System.out.println("Pantalón		4			22€");
		System.out.println("Calcetines		5			17€");
		System.out.println("Faldas			6			5€");
		System.out.println("Gorras			7			8€");
		System.out.println("Sueter			8			12€");
		System.out.println("Corbata			9			45€");
		System.out.println("Chaqueta		10			80€");
		System.out.println();
		
		System.out.println("Teclea el codigo del producto que quieres comprar:");
			producto=teclado.nextByte();
		System.out.println("Teclea la cantidad que quieres comprar de dicho producto:");
			cantidad=teclado.nextByte();
		
		switch(producto){
			case 1:
				producto=10;
				break;
			case 2:
				producto=15;
				break;
			case 3:
				producto=20;
				break;
			case 4:
				producto=22;
				break;
			case 5:
				producto=17;
				break;
			case 6:
				producto=5;
				break;
			case 7:
				producto=8;
				break;
			case 8:
				producto=12;
				break;
			case 9:
				producto=45;
				break;
			case 10:
				producto=80;
				break;
		}	
		
		precioT=producto*cantidad;
		
		
		System.out.println("En total, el cliente tendrá que pagar: "+ precioT);
		
	}

}
