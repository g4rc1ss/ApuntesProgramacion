package Thread;

public class HiloConInterface implements Runnable {
    int x;
    // Constructor
    public HiloConInterface(int x) {
        this.x = x;
    }

    // Metodo que hay que implementar
    public void run() {
        for (int i = 0; i < x; i++)
            System.out.println("En hilo " + x + ". Paso numero " + i);
    }
}