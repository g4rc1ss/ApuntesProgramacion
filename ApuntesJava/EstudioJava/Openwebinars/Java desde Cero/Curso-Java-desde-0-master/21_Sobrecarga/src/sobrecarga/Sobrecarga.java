/**
 * 
 */
package sobrecarga;

/**
 * @author Openwebinars
 *
 */
public class Sobrecarga {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		Artista artista = new Artista();
		
		artista.dibuja("Hola");
		artista.dibuja(7);
		artista.dibuja(7, 8.3f);
		
		
		Persona perso1 = new Persona();
		Persona perso2 = new Persona("Pepe", "P�rez");
		Persona perso3 = new Persona("Alejandro", "Ruiz", 33);
		Persona perso4 = new Persona("Miguel", "G�mez", 25, 180, 75f);
		
		System.out.println(perso1);
		System.out.println(perso2);
		System.out.println(perso3);
		System.out.println(perso4);
		
	}

}
