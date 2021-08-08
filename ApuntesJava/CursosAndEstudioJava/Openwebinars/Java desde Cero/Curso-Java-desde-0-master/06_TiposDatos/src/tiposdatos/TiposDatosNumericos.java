/**
 * 
 */
package tiposdatos;

/**
 * @author Openwebinars
 *
 */
@SuppressWarnings("all")
public class TiposDatosNumericos {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		
		/*
		 * LITERALES
		 */
		
		//Valor booleano VERDADERO
		boolean resultado = true;
		//Letra C
		char letraMayuscula = 'C';
		//N�mero 100
		byte by = 100;
		//N�mero 1000
		short sh = 1000;
		//N�mero 1000000
		int in = 1000000;
		
		//Valor 26, en decimal
		int decVal = 26;
		//Valor 26, en hexadecimal
		int hexVal = 0x1a;
		//Valor 26, en binario
		int binVal = 0b11010;
		
		//String s = "Hola Mundo";
		
		/*
		 * TIPOS DE DATOS NUM�RICOS
		 */
		
		//TIPOS DE DATOS ENTEROS
		//[-128,127]
		byte b = 28;
		//[-32768,32767]
		short s = 3458;
		//[-2^31,(2^31)-1]
		int i = 33456;
		//[-2^63,(2^63)-1]
		long l = 3_000_000_000L;
		
		
		//TIPOS DE DATOS REALES
		//Precisi�n simple
		float f = 0.25f;
		//Precisi�n doble
		double Pi = Math.PI;
		
		
		
		//OPERADORES NUM�RICOS
		int x = 7;
		int y = 5;
		
		//Suma
		int z = x + y;
		System.out.print("Suma ");
		System.out.println(z);
		
		//Resta
		z = x - y;
		System.out.print("Resta ");
		System.out.println(z);
		
		//Multiplicaci�n
		z = x * y;
		System.out.print("Multipliaci�n ");		
		System.out.println(z);
		
		
		//Divisi�n (entera)
		z = x / y;
		System.out.print("Divisi�n entera ");		
		System.out.println(z);
		
		//Divisi�n (no entera)
		double j = Pi/f;
		System.out.println("Divisi�n con decimales ");
		System.out.println(j);
				
		//Resto
		z = x % y;
		System.out.print("M�dulo o resto ");		
		System.out.println(z);
		
		//Incremento
		z = x++;
		System.out.print("Incremento ");		
		System.out.println(z);
		System.out.println(x);
		
		
		
		//OPERADORES A NIVEL DE BITS
		int bitmask = 0b0011; 
		int val = 0b1111; 
		
		int res = val & bitmask; //0011
		System.out.print("AND ");
		System.out.println(Integer.toBinaryString(res));
		
		res = val ^ bitmask; //1100
		System.out.print("OR exclusivo ");		
		System.out.println(Integer.toBinaryString(res));
				
		res = val | bitmask; //1111
		System.out.print("OR inclusivo ");
		System.out.println(Integer.toBinaryString(res));
		
		// 0b1111
		
		res = val << 1; //11110
		System.out.print("left shift ");		
		System.out.println(Integer.toBinaryString(res));
				
		res = val >> 2; //0011
		System.out.print("Signed rigth shift ");		
		System.out.println(Integer.toBinaryString(res));
		
		
		res = (-val) >> 2; //11111111111111111111111111111100
		System.out.print("Signed rigth shift ");		
		System.out.println(Integer.toBinaryString(res));
				
		res = val >>> 1; //111
		System.out.print("Unsigned rigth shift ");		
		System.out.println(Integer.toBinaryString(res));
		
		res = ~val; //11111111111111111111111111110000
		System.out.print("Inverso o complementario ");
		System.out.println(Integer.toBinaryString(res));

//		int a = 5;
//		int b = 9;
//		
//		System.out.println((double)a/b);
		
			
		
		
		

	}

}
