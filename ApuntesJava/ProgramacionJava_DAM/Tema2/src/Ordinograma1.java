/*
  Leer tres n�meros y calcular la media
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
       
        System.out.println("Introduzca el primer n�mero");
        num1 = teclado.nextFloat();
        System.out.println("Introduzca el segundo n�mero");
        num2 = teclado.nextFloat();
        System.out.println("Introduzca el tercer n�mero");
        num3= teclado.nextFloat();
        //diferencia entre divisi�n entera y real
        System.out.print("\nLa media de los tres n�meros es " +(int)((num1+num2+num3)/3));
        System.out.print("\nLa media de los tres n�meros es "+((num1+num2+num3)/3));
        //Tambi�n podemos formatear la salida:
        System.out.printf("\nLa media de los tres n�meros es %d",(int)((num1+num2+num3)/3));
        System.out.printf("\nLa media de los tres n�meros es %.2f",((num1+num2+num3)/3));
        
    }
}
