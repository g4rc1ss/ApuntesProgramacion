package EjerAnimal;
/*
 Ejercicio.-
Clase Animal:
�	Atributos: nombre, edad.
�	M�todo constructor: recibe nombre y edad.
�	M�todo hablar: para visualizar  c�mo se llama y qu� edad tiene.
�	M�todo pedirDatos: para poder pedir el nombre y la edad introducida por teclado.
 */

import java.util.Scanner;

/*-------------------------------------------------------------------------------------------------------------------------------------------*/
/*-----------------------------------------------Inicio Clase Animal-------------------------------------------------------------------------*/
/*-------------------------------------------------------------------------------------------------------------------------------------------*/

class Animal {
    Scanner teclado = new Scanner(System.in);
    String nombre;
    int edad;

    Animal(String nombre, int edad) {
        this.nombre = nombre;
        this.edad = edad;
    }

    void Hablar() {
        System.out.println("El animal se llama " + nombre + " y tiene " + edad + " a�os.");
    }

    void pedirDatos() {
        System.out.println("Escribe el nombre del animal:");
        nombre = teclado.nextLine();
        System.out.println("Escribe la edad del animal:");
        edad = teclado.nextInt();
    }

}
/*--------------------------------------------------Fin Clase Animal-------------------------------------------------------------------------*/

/*
 Clase P�jaro subclase de Animal:
�	Atributo: clima.
�	M�todo constructor: recibe nombre, edad, clima.
�	M�todo redefinido hablar, para llamar al m�todo hablar del padre y para indicar en que clima vive.
�	M�todo redefinido pedirDatos, para llamar al m�todo pedirDatos del padre y pedir que introduzca el clima por teclado.
 */

/*-------------------------------------------------------------------------------------------------------------------------------------------*/
/*-----------------------------------------------Inicio Clase Pajaro-------------------------------------------------------------------------*/
/*-------------------------------------------------------------------------------------------------------------------------------------------*/
class Pajaro extends Animal {
    Scanner teclado = new Scanner(System.in);

    String clima;

    Pajaro(String nombre, String clima, int edad) {
        super(nombre, edad);
        this.clima = clima;
    }

    void Hablar() { /*----Metodo redefinido----*/
        super.Hablar();
        System.out.println("El clima en el que vive este animal es: " + clima);
    }

    void pedirDatos() { /*----Metodo redefinido----*/
        super.pedirDatos();
        System.out.println("Escribe el clima en el que vive el animal:");
        clima = teclado.nextLine();
    }
}
/*--------------------------------------------------Fin Clase Pajaro-------------------------------------------------------------------------*/

/*
 Clase Loro subclase de P�jaro:
�	Atributo: color.
�	M�todo constructor: recibe nombre, edad,clima,color.
�	M�todo redefinido hablar, para llamar al m�todo hablar del padre (clase anterior) y para indicar su color.
�	M�todo redefinido pedirDatos, para llamar al m�todo pedirDatos del padre (clase anterior) y para pedir que introduzca el color por teclado.
 
 */

/*-------------------------------------------------------------------------------------------------------------------------------------------*/
/*-----------------------------------------------Inicio Clase Loro---------------------------------------------------------------------------*/
/*-------------------------------------------------------------------------------------------------------------------------------------------*/
class Loro extends Pajaro {
    Scanner teclado = new Scanner(System.in);

    String color;

    Loro(String nombre, String clima, String color, int edad) {
        super(nombre, clima, edad);
        this.color = color;

    }

    void Hablar() { /*----Metodo redefinido----*/
        super.Hablar();
        System.out.println("El animal es de color " + color);
    }

    void pedirDatos() { /*----Metodo redefinido----*/
        super.pedirDatos();
        System.out.println("Escribe el color del animal:");
        color = teclado.nextLine();
    }

}
/*--------------------------------------------------Fin Clase Loro---------------------------------------------------------------------------*/


/*
 Programa principal:
�	Crear una instancia de Loro.
�	Crear una instancia de P�jaro.
�	Crear una instancia de Animal.
�	Hacer hablar al loro creado, al p�jaro creado, al animal creado.
�	pedirDatos al loro, al p�jaro, al animal creados.
�	Hacer hablar al loro, al p�jaro, al animal creados. 
*/

/*-------------------------------------------------------------------------------------------------------------------------------------------*/
/*----------------------------------------------------*/    /*-------------------------------------------------------------------------------*/
/*-----------------------------------------------INICIO CLASE MAIN---------------------------------------------------------------------------*/
/*----------------------------------------------------*/   /*--------------------------------------------------------------------------------*/
/*-------------------------------------------------------------------------------------------------------------------------------------------*/

public class MainAnimal {
    public static void main(String[] args) {
		
		/*
		
		Loro lor = new Loro ("Tobi", "Mediterraneo", "Gris", 5);
		Pajaro paj = new Pajaro ("Lechucico","Atlantico", 10000);
		Animal ani = new Animal ("Pedrito", 31);
		
		lor.Hablar();
		paj.Hablar();
		ani.Hablar();
		
		lor.pedirDatos();
		paj.pedirDatos();
		ani.pedirDatos();
		
		lor.Hablar();
		paj.Hablar();
		ani.Hablar();	*/

        /*__________________________________________________POLIMORFISMO____________________________________________*/


        System.out.println("Polimorfismo, crear tres instancias de animal que se llamn L,P,A");
        Animal lor, paj, ani;

        lor = new Loro(null, null, null, 0);
        paj = new Pajaro(null, null, 0);
        ani = new Animal(null, 0);



        /*__________________________________________________ARRAYS____________________________________________*/


    }

}



/*--------------------------------------------------FIN CLASE PRINCIPAL---------------------------------------------------------------------*/

	




























