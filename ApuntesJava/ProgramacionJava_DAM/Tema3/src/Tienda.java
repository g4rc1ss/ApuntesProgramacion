/*1.- Crear la clase Tiendas con los atributos: cif (c�digo de identificaci�n fiscal), nombre de tienda, telefono, calle, n� , web,fax, mail, dni due�o, nombre, apellido 1, apellido2.
En el constructor teclear datos correspondientes a los atributos nombrados anteriormente.

Codificar un m�todo que visualice: nombre de la tienda y el tel�fono.

Codificar otro m�todo que visualice: cif, nombre del/a due�o/a , apellido1, apellido2.

Crear un objeto perteneciente a la clase Tiendas y llamar a cada uno de los m�todos  creados.
*/

import java.util.Scanner;

public class Tienda {


    String nombreTienda, nombre, apellido1, apellido2, dniDueno,mail,web,calle,cif;
    byte numeroCalle;
    long telefono, fax;
    Scanner teclado = new Scanner(System.in);

    Tienda() {
        System.out.println("Teclea el nombre de la tienda");
        nombreTienda = teclado.nextLine();
        System.out.println("Teclea el nombre");
        nombre = teclado.nextLine();
        System.out.println("Teclea el primer apellido");
        apellido1 = teclado.nextLine();
        System.out.println("Teclea el segundo apellido");
        apellido2 = teclado.nextLine();
        System.out.println("Teclea el DNI del due�o de la tienda");
        dniDueno = teclado.nextLine();
        System.out.println("Teclea el e-mail");
        mail = teclado.nextLine();
        System.out.println("Teclea la calle");
        calle = teclado.nextLine();
        System.out.println("Teclea la web");
        web = teclado.nextLine();
        System.out.println("Teclea el CIF");
        cif = teclado.nextLine();
        System.out.println("Teclea el numero de la calle");
        numeroCalle = teclado.nextByte();
        System.out.println("Teclea el telefono");
        telefono = teclado.nextInt();
        System.out.println("Teclea el fax");
        fax = teclado.nextInt();
    }

    void ObtenerNombreNumero() {
        System.out.println("El nombre de la tienda es " + nombreTienda + " y su numero de telefono es " + telefono);
    }

    void ObtenerDatosTienda() {
        System.out.println("El CIF es " + cif + "yk',o00' el nombre completo del due�o es " + nombre + " " + apellido1 + " " + apellido2);
    }

    void metodo3() {
        System.out.println("El nombre de la tienda es " + nombreTienda + " y su numero d telefono es " + telefono);
    }


    public static void main(String[] args) {

        Tienda T = new Tienda();
        T.ObtenerNombreNumero();
        T.ObtenerDatosTienda();

    }

}
