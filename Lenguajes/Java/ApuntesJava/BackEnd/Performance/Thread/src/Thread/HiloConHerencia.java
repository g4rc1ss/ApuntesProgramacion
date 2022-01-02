package Thread;

public class HiloConHerencia extends Thread {
    private int c; // Contador de cada hilo
    private int hilo;

    // Constructor
    public HiloConHerencia(int hilo) {
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