import java.util.Scanner;

public class Ordinograma3 {

        public static void main(String[] args) {
        float pvp,importe,piva,precio,iva;
        int cantidad;
 
     
        Scanner teclado = new Scanner(System.in);
               
      
        //ESCRIBIR "Introduzca precio producto"
        System.out.println("Introduzca precio producto");
        //LEER precio
        precio = teclado.nextFloat();
      
        //ESCRIBIR "Introduzca cantidad"
        System.out.println("Introduzca cantidad");
        //LEER cantidad
        cantidad = teclado.nextInt();
      
        //ESCRIBIR "Introduzca iva (en tanto por ciento )"
        System.out.println("Introduzca iva (por ejemplo si el iva es: 10%, teclear 10)");
        //LEER iva
        iva = teclado.nextFloat();
      
        //Calculamos las cantidades con y sin iva
        importe= precio*cantidad;
        piva = precio*cantidad*iva/100;
        pvp = importe+piva;
      
    System.out.println("Aqui tienes que visualizar lo que te parezca lógico del programa");
              
      
  
  
    }
}
