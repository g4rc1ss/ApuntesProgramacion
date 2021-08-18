

 /* Leer dos números y mostrar cuál es el mayor , cuál el menor y si son iguales mostrar un mensaje */
import java.util.Scanner;
public class Ordinograma2 {   
    public static void main(String[] args) {
        int num1,num2,num3;
        Scanner entrada = new Scanner(System.in);
       
        //ESCRIBIR Introduzca el primer número
        System.out.println("Introduzca el primer número");
        //LEER num1
        num1 = entrada.nextInt();
        //ESCRIBIR Introduzca el seg número
        System.out.println("Introduzca el segundo número");
        //LEER num2
        num2 = entrada.nextInt();   
        /* El pseudocódigo es:
         SI num1>num2
         *  ESCRIBR num1,num2
         * SINO
         *  ESCRIBIR num2,num1
         finsi
         */   
       
       
        if (num1 > num2) {
            System.out.println(" El número: " + num1 + " es mayor que el número: "+ num2);
           
        }else if (num2>num1){
        	System.out.println(" El número: " + num2 + " es mayor que el número: "+ num1);
            }
            else {
            	System.out.println(" Los 2 números son iguales");
            }
               
    }
}

