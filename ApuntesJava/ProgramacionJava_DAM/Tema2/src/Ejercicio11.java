/*11.- Este programa muestra los pagos que recibir� un trabajador por cada hora laboral en 
 base a la hora del d�a en que trabaja. El usuario deber� escribir el n�mero de horas 
 trabajadas en cada uno de los horarios y el programa determinar� el total de dinero a recibir 
 por el trabajador y tambi�n dir� si gan� m�s dinero por horas extras que por horas de oficina 
 trabajadas o viceversa, o si el trabajador gan� ex�ctamente lo mismo por horas extras que por 
 horas de oficina.*/

import java.util.Scanner;

public class Ejercicio11 {

	public static void main(String[] args) {
		Scanner teclado=new Scanner(System.in);

		//Variables
		double horario1;
		double horario2;
		double horario3;
		double horario4;
		
		//Codigo
		
		System.out.println("Teclea las horas que has trabajado de 8AM a 4PM");
			horario1=teclado.nextDouble();
		System.out.println("Teclea las horas que has trabajado de 4PM a 8PM");
			horario2=teclado.nextDouble();
		System.out.println("Teclea las horas que has trabajado de 8PM a 12AM");
			horario3=teclado.nextDouble();
		System.out.println("Teclea las horas que has trabajado de 12AM a 8AM");
			horario4=teclado.nextDouble();
		
		horario1=(horario1*12);
		horario2=(horario2*(12*1.25));
		horario3=(horario3*(12*1.5));
		horario4=(horario4*(12*2));
			
		double horasExtra;
		
		horasExtra=(horario2+horario3+horario4);
		
		System.out.println("El salario total conseguido es: "+(horario1+horasExtra));
		System.out.println("El salario conseguido en un horario normal es: "+horario1);
		System.out.println("El salario conseguido en horas extra es: "+horasExtra);	
			
		if(horario1>horasExtra){
			System.out.println("Has ganado mas dinero por horas de oficina que por horas extra");
		}
		else if(horasExtra>horario1){
			System.out.println("Has ganado mas dinero por horas extra que por horas de oficina");
		}
		else
			System.out.println("Has ganado lo mismo en las horas de oficina que en las horas extra");
		
		
		
		
	}

}
