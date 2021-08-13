package Thread.ContarLineasConThreads;

public class Cuentalineas {
    public static void main(String[] args) throws InterruptedException {
        int max = 0;
        Fichero cuenta1 = new Fichero("fichero1.txt");
        Fichero cuenta2 = new Fichero("fichero2.txt");
        Fichero cuenta3 = new Fichero("fichero3.txt");
        Fichero cuenta4 = new Fichero("fichero4.txt");
        cuenta1.start();
        cuenta2.start();
        cuenta3.start();
        cuenta4.start();
        
        cuenta1.join();
        cuenta2.join();
        cuenta3.join();
        cuenta4.join();
        // sleep(5);
        System.out.println(
                "El número mayor de líneas es: " +
                        Fichero.maximo + " del fichero: " +
                        Fichero.ficherogrande
        );

    }
}
