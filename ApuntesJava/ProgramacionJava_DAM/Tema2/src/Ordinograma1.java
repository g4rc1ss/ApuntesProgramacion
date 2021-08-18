/*
  Leer tres números y calcular la media
 */

import java.util.Scanner;
/**
 *
 * @author Pilar Lekue
 */
public class Ordinograma1 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        float num1,num2,num3;
        Scanner teclado = new Scanner(System.in);
       
        System.out.println("Introduzca el primer número");
        num1 = teclado.nextFloat();
        System.out.println("Introduzca el segundo número");
        num2 = teclado.nextFloat();
        System.out.println("Introduzca el tercer número");
        num3= teclado.nextFloat();
        //diferencia entre división entera y real
        System.out.print("\nLa media de los tres números es " +(int)((num1+num2+num3)/3));
        System.out.print("\nLa media de los tres números es "+((num1+num2+num3)/3));
        //También podemos formatear la salida:
        System.out.printf("\nLa media de los tres números es %d",(int)((num1+num2+num3)/3));
        System.out.printf("\nLa media de los tres números es %.2f",((num1+num2+num3)/3));
        
    }
}
