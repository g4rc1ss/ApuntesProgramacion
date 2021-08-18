import java.util.Scanner;

public class EjercicioSueldo {

    public static void main(String[] args) {
        // TODO Auto-generated method stub
        Scanner teclado = new Scanner(System.in);

        //Variables
        double sueldo;
        double antiguedad;
        double sueldoFinal;
        //Codigo

        System.out.println("Teclea tu sueldo: ");
        sueldo = teclado.nextDouble();

        if (sueldo < 2000) {
            System.out.println("Teclea tu antiguedad en la empresa: ");
            antiguedad = teclado.nextDouble();

            if (antiguedad >= 10) {
                sueldoFinal = sueldo * 1.20;
            } else {
                sueldoFinal = sueldo * 1.10;
            }
        } else {
            sueldoFinal = sueldo;
        }

        System.out.println("El sueldo es: " + sueldoFinal);


    }

}
