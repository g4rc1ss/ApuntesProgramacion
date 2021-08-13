/**
 * EJEMPLO DE USO DEL M�TODO FOREACH JUNTO CON EXPRESIONES LAMBDA
 */
package lambda;

import java.util.Arrays;
import java.util.List;

/**
 * @author Openwebinars
 *
 */
public class B_Foreach {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		
		List<Integer> lista = Arrays.asList(1,2,3,4,5,6,7,8,9,10);
		
		//1� Forma cl�sica de imprimir los elementos de una lista
//		for(Integer i: lista)
//			System.out.println(i);
		
		//2� Uso de forEach
//		lista.forEach(e -> System.out.println(e));
		
		//3� Uso de referencias a m�todos con ::
//		lista.forEach(System.out::println);
		
		//4� Uso de un bloque de sentencias que suma un valor fijo a los 
		//elementos de la lista
//		lista.forEach((e) -> {
//			e = e+1;
//			System.out.println(e);
//		});
		
		

	}

}
