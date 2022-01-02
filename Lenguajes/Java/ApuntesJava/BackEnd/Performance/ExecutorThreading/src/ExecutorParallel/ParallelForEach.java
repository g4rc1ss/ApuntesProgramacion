package ExecutorParallel;

import java.util.ArrayList;

public class ParallelForEach {
    public ParallelForEach() {
        System.out.println("----------------- EMPIEZA EL PARALLEL FOREACH ----------------");
        var lista = new ArrayList<Integer>();
        for (int x = 0; x < 1000; x++) {
            lista.add(x);
        }

        //Para paralelizar una lista mediante una funcion automatizada pasandole una lambda
        lista.parallelStream().forEach(System.out::println);

        System.out.println("----------------- TERMINA FOREACH PARALELIZADO --------------------");
    }
}
