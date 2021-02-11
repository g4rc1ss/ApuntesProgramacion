package Thread;

public class ThreadConExtendsHerencia {
    public static void main(String[] args) {
        HiloEjemplo h = null;
        for (int i = 0; i < 3; i++) {
            h = new HiloEjemplo(i + 1); // Se crea el hilo
            h.start(); // Se inicia el hilo
        }
        System.out.println("3 HILOS CREADOS...");
    }
}

class HiloEjemplo extends Thread {
    private int c; // Contador de cada hilo
    private int hilo;

    // Constructor
    public HiloEjemplo(int hilo) {
        this.hilo = hilo;
        System.out.println("CREANDO HILO: " + hilo);
    }

    // Metodos
    /* el metodo run se ejecuta tras el start del objeto en el main */
    public void run() {
        c = 0;
        while (c <= 5) {
            System.out.println("el hilo " + hilo + ", C = " + c);
            c++;
        }
    } // fin del run
}