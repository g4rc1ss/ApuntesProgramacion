/*7.- Mostrar el signo del zodíaco de una persona.
Para ello el usuario debe introducir el día y el mes de nacimiento.
Realizar el ejercicio anterior con if.*/
import java.util.Scanner;
public class Ejercicio7 { 
    public static void main(String[] args) {
    	Scanner teclado=new Scanner(System.in);
    	//Variables
        int mes;
        int dia;
        
        //Codigo
        System.out.println("Teclea un dia:");
        	dia=teclado.nextInt();
        System.out.println("Teclea un mes:");
          	mes=teclado.nextInt();

        if      ((mes == 12 && dia >= 22 && dia <= 31) || (mes ==  1 && dia >= 1 && dia <= 19))
            System.out.println("Capricornio");
        else if ((mes ==  1 && dia >= 20 && dia <= 31) || (mes ==  2 && dia >= 1 && dia <= 17))
            System.out.println("Aquarius");
        else if ((mes ==  2 && dia >= 18 && dia <= 29) || (mes ==  3 && dia >= 1 && dia <= 19))
            System.out.println("Piscis");
        else if ((mes ==  3 && dia >= 20 && dia <= 31) || (mes ==  4 && dia >= 1 && dia <= 19))
            System.out.println("Aries");
        else if ((mes ==  4 && dia >= 20 && dia <= 30) || (mes ==  5 && dia >= 1 && dia <= 20))
            System.out.println("Tauro");
        else if ((mes ==  5 && dia >= 21 && dia <= 31) || (mes ==  6 && dia >= 1 && dia <= 20))
            System.out.println("Geminis");
        else if ((mes ==  6 && dia >= 21 && dia <= 30) || (mes ==  7 && dia >= 1 && dia <= 22))
            System.out.println("Cancer");
        else if ((mes ==  7 && dia >= 23 && dia <= 31) || (mes ==  8 && dia >= 1 && dia <= 22))
            System.out.println("Leo");
        else if ((mes ==  8 && dia >= 23 && dia <= 31) || (mes ==  9 && dia >= 1 && dia <= 22))
            System.out.println("Virgo");
        else if ((mes ==  9 && dia >= 23 && dia <= 30) || (mes == 10 && dia >= 1 && dia <= 22))
            System.out.println("Libra");
        else if ((mes == 10 && dia >= 23 && dia <= 31) || (mes == 11 && dia >= 1 && dia <= 21))
            System.out.println("Scorpio");
        else if ((mes == 11 && dia >= 22 && dia <= 30) || (mes == 12 && dia >= 1 && dia <= 21))
            System.out.println("Sagitario");
      

    }

}

