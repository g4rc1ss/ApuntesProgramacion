package ArrayList;

/*
Ejemplo 2: Codifica un programa donde teclees números enteros y los guarde en un ArrayList hasta que teclees un 0 (el 0 no se guarda). 
Visualizar los números tecleados, su suma y su media.
 */
import java.util.Scanner;
import java.util.ArrayList;

public class Ejercicio2 {

    Scanner teclado = new Scanner(System.in);
    ArrayList<Integer> numeros = new ArrayList<Integer>();
    int n;

    void introducir() {

        System.out.println("Teclea un número: ");
        n = teclado.nextInt();

        while (n != 0);
        {
            numeros.add(n);

            System.out.println("Teclea número: ");
            numeros.add(teclado.nextInt());
        }

    }

    void visualizar() {

        System.out.println("Los numeros del array son: ");
        for (Integer i : numeros) {
            System.out.println(i);

            int suma = 0;
            System.out.println("La suma de los numeros es: " + (suma += i));
            int media;
            media = suma / numeros.size();
            System.out.println("La media de los numeros es: " + media);

        }

    }

    public static void main(String[] args) {

        Ejercicio2 obj = new Ejercicio2();
        obj.introducir();
        obj.visualizar();

    }

}
