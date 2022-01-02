import Thread.HiloConHerencia;
import Thread.HiloConInterface;

public class MultiThreading {
    public static void main(String[] args) {
        var hilo = new HiloConHerencia(1); // Se crea el hilo
        hilo.start(); // Se inicia el hilo

        HiloConInterface p = new HiloConInterface(5);
        new Thread(p).start();

        new Thread(() -> {
            System.out.println("Hilo con lambda");
        }).start();
    }
}
