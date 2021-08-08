/**
 * EJEMPLO DE USO DE EXPRESIONES LAMBDA PARA ORDENAR
 */
package lambda;

import java.util.Arrays;
import java.util.Comparator;
import java.util.List;

/**
 * @author Openwebinars
 *
 */
public class A_Lambda {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		
		List<Integer> lista = Arrays.asList(1,2,3,4,5,6,7,8,9,10);
		
		//1� Forma: una clase que implementa comparator
		//lista.sort(new MayorAMenor());
		
		//2� Forma: una clase "an�nima"
		//�Qu� tal si ponemos el cursor sobre la instanciaci�n de la clase
		//an�nima y pulsamos Ctrl+1?
		//Eclipse permite convertir esto en una expresi�n lambda autom�ticamente
//		lista.sort(new Comparator<Integer>() {
//
//			@Override
//			public int compare(Integer o1, Integer o2) {
//				return -(o1.compareTo(o2));
//			}
//			
//		});
		
		//3� Forma: una expresion lambda
		//Los tipos de datos �no son obligatorios! Se infieren del contexto		
//		lista.sort((Integer n1, Integer n2) -> -(n1.compareTo(n2))); 
		lista.sort((n1, n2) -> -(n1.compareTo(n2)));
		
		for (Integer i : lista)
			System.out.println(i);

	}

}
