/**
 * EJEMPLO DEL USO DEL API STREAM JUNTO CON EXPRESIONES LAMBDA
 */
package ejemplolambda;

import java.util.Arrays;
import java.util.List;

/**
 * @author Openwebinars
 *
 */
public class B_ApiStream {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		
		List<Integer> lista = Arrays.asList(1,2,3,4,5,6,7,8,9,10);
		
		//1� Imprimir todos los elementos de la lista
//		lista
//			.stream()
//			.forEach((n) -> System.out.println(n));
		
		//2� Imprimir solo los mayores o iguales que 5
//		lista
//			.stream()
//			.filter((x) -> x >= 5)
//			.forEach((n) -> System.out.println(n));
		
		//3� Imprimir solo los mayores o iguales que 5, ordenados inversamente
//		lista
//			.stream()
//			.filter((x) -> x >= 5)
//			.sorted((n1, n2) -> -(n1.compareTo(n2)))
//			.forEach((n) -> System.out.println(n));
		
//		//4� Sumar todos los elementos mayores o igual que 5
		int resultado = lista
								.stream()
								.mapToInt(v -> v.intValue())
								.filter((x) -> x >= 5)
								.sum();
		System.out.println(resultado);

	}

}
