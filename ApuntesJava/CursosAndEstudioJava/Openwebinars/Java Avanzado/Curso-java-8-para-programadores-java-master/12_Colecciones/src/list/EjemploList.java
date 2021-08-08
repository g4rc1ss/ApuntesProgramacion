/**
 * 
 */
package list;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

import modelo.Persona;

/**
 * @author Openwebinars
 *
 */
public class EjemploList {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		
		List<Persona> listaPersonas = new ArrayList<>();
		//List<Persona> listaPersonas = new LinkedList<>();
		
		listaPersonas.add(new Persona("12345678A", "Pepe", "Perez", LocalDate.of(1990, 1, 2)));
		listaPersonas.add(new Persona("23456789B", "Juan", "Mart�nez", LocalDate.of(1991, 2, 3)));
		listaPersonas.add(new Persona("34567890C", "Ana", "Ram�rez", LocalDate.of(1992, 3, 4)));
		listaPersonas.add(new Persona("45678901D", "Mar�a", "L�pez", LocalDate.of(1993, 4, 5)));
		
		//Acceso posicional (3� posici�n)
		Persona p = listaPersonas.get(2);
		System.out.println(p);
		System.out.println("\n\n");
		
		//Recorrer la lista completa
		for(Persona per : listaPersonas)
			System.out.println(per);
		
		
		//A�adir un nuevo elemento al final de la lista
		listaPersonas.add(new Persona("56789012E", "Julio", "Azc�rate", LocalDate.of(1994, 5, 6)));
		
		//A�adir/modificar un elemento en medio de la lista
		listaPersonas.set(2, new Persona("67890123F", "Alfonso", "Garc�a", LocalDate.of(1995, 6, 7)));
		
		//Recorrer la lista completa
		System.out.println("\n\n\n");
		for(Persona per : listaPersonas)
			System.out.println(per);
		
		//Para ordenar, tenemos que aportar un orden
		//Ser� por fecha de nacimiento, a la inversa
		listaPersonas.sort(new Comparator<Persona>() {

			@Override
			public int compare(Persona p1, Persona p2) {
				return -p1.getFechaNacimiento().compareTo(p2.getFechaNacimiento());
			}
			
		});
		
		//Recorremos la lista completa, ya ordenada
		System.out.println("\n\n\n");
		for(Persona per : listaPersonas)
			System.out.println(per);
		
		
		
		
	}

}
