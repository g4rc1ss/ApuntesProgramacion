

 /* Leer dos n�meros y mostrar cu�l es el mayor , cu�l el menor y si son iguales mostrar un mensaje */
import java.util.Scanner;
public class Ordinograma2 {   
    public static void main(String[] args) {
        int num1,num2,num3;
        Scanner entrada = new Scanner(System.in);
       
        //ESCRIBIR Introduzca el primer n�mero
        System.out.println("Introduzca el primer n�mero");
        //LEER num1
        num1 = entrada.nextInt();
        //ESCRIBIR Introduzca el seg n�mero
        System.out.println("Introduzca el segundo n�mero");
        //LEER num2
        num2 = entrada.nextInt();   
        /* El pseudoc�digo es:
         SI num1>num2
         *  ESCRIBR num1,num2
         * SINO
         *  ESCRIBIR num2,num1
         finsi
         */   
       
       
        if (num1 > num2) {
            System.out.println(" El n�mero: " + num1 + " es mayor que el n�mero: "+ num2);
           
        }else if (num2>num1){
        	System.out.println(" El n�mero: " + num2 + " es mayor que el n�mero: "+ num1);
            }
            else {
            	System.out.println(" Los 2 n�meros son iguales");
            }
               
    }
}

