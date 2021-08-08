/**
 * 
 */
package collectors;

import java.util.Comparator;
import java.util.IntSummaryStatistics;
import java.util.List;
import java.util.Optional;
import java.util.Random;
import java.util.stream.Collectors;

/**
 * @author Openwebinars
 *
 */
public class A_CollectorsBasicos {

	/**
	 * @param args
	 */
	public static void main(String[] args) {


		/*
		 * Empezamos el ejemplo con un ejemplo :)
		 * 
		 * La clase Random incluye m�todos que trabajan con streams, y nos permiten crear
		 * uno de n�meros aleatorios (ints). A continuaci�n, lo limitamos a 20 elementos (limit).
		 * Posteriormente, indicamos que en lugar de un IntStream, queremos obtener un
		 * Stream<Integer> (boxed). Por �ltimo, usamos la operaci�n collect con el primer
		 * Collector del ejemplo: toList, que nos devuelve un List<Integer> a partir del stream.
		 * 
		 */
		Random r = new Random();
		List<Integer> numeros =  r.ints(0, 1000).limit(20).boxed().collect(Collectors.toList());
		
		// Colectores "b�sicos"
		
		long total = numeros.stream().collect(Collectors.counting());
		System.out.println("El total de elementos de la colecci�n es: " + total);
		
		// MaxBy
		Optional<Integer> maximo = numeros.stream().collect(Collectors.maxBy(Comparator.naturalOrder()));
		System.out.println("El m�ximo de la colecci�n es: " + maximo.orElse(0));
		
		// SummingInt
		int suma = numeros.stream().collect(Collectors.summingInt(v -> v.intValue()));
		System.out.println("La suma de todos los elementos de la colecci�n es: " + suma);
		
		// AveragingInt
		double media = numeros.stream().collect(Collectors.averagingInt(Integer::intValue));
		System.out.printf("La media de todos los elementos de la colecci�n es %.2f %n ", media);
		
		// SummarazingInt		
		IntSummaryStatistics res = numeros.stream().collect(Collectors.summarizingInt(Integer::intValue));
		System.out.println("El m�nimo de todos los elementos de la colecci�n es: " + res.getMin());
		
		
		// Join de cadenas de caracteres
		String strNumeros = numeros.stream().sorted().map(Object::toString).collect(Collectors.joining(", "));
		System.out.println("Los n�meros de la colecci�n son " + strNumeros);
		
		
		

	}

}
