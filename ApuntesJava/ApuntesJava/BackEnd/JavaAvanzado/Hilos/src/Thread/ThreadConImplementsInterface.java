package Thread;

public class ThreadConImplementsInterface {
    public static void main(String[] args) {
        Hilo p = new Hilo(5);
        new Thread(p).start();
    }
}

class Hilo implements Runnable {
    int x;
    // Constructor
    public Hilo(int x) {
        this.x = x;
    }

    // Metodo que hay que implementar
    public void run() {
        for (int i = 0; i < x; i++)
            System.out.println("En hilo " + x + ". Paso numero " + i);
    }
}