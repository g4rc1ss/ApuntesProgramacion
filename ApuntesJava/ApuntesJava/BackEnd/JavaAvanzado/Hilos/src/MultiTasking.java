import ExecutorsThreading.ParallelForEach;
import ExecutorsThreading.ParallelInvoke;

public class MultiTasking {
    public static void main(String[] args) {
        System.out.println("--------------------- EMPEZAMOS -----------------------");
        new ParallelForEach();
        new ParallelInvoke();
        System.out.println("--------------------- TERMINADO -----------------------");
    }
}
