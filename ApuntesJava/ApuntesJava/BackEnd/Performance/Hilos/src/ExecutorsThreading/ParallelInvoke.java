package ExecutorsThreading;

import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.concurrent.Callable;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.ForkJoinPool;

public class ParallelInvoke {
    public ParallelInvoke() {
        // Declaramos el servicio de creacion de tareas:
        var tareas = new HashMap<String, ExecutorService>();

        ///////////////////////// Agregamos las configuraciones: \\\\\\\\\\\\\\\\\\\\\\\\\\\

        // Crea todos los hilos que sean necesarios hasta el tope(que seria el maximo de procesadores del equipo),
        // reutilizando los ya creados a medida que quedan libres y destruyendo los que están un tiempo sin actividad
        tareas.put("newCachedThreadPool", Executors.newCachedThreadPool());

        // Hace la operacion que le indices creando 1 solo subproceso o hilo para toda la ejecucion
        tareas.put("newSingleThreadExecutor", Executors.newSingleThreadExecutor());

        // Realiza la operacion con un maximo de hilos creado por el propio usuario, en este ejemlo se obtiene el numero
        // de procesadores que dispone el equipo y le indica que se va a usar como mucho la mitad.
        tareas.put("newFixedThreadPool", Executors.newFixedThreadPool(Runtime.getRuntime().availableProcessors() / 2));

        // Realiza la operacion usando todos los procesadores del equipo
        tareas.put("newWorkStealingPool", Executors.newWorkStealingPool());

        // Realiza la operacion de la forma mas comun,que es usando todos los procesadores, menos 1
        // para no acaparar todos los recursos, deja uno disponible
        tareas.put("commonPool", ForkJoinPool.commonPool());


        tareas.forEach((key, value) -> {
            System.out.println("\n" +
                    "------------ USAMOS " + key + "-----------------");
            var taskToExecute = new ArrayList<Callable<Object>>();

            for (var x = 0; x < Runtime.getRuntime().availableProcessors(); x++) {
                taskToExecute.add(() -> {
                    Thread.sleep(1000);
                    return 0;
                });
            }

            try {
                System.out.println(new Date());
                var x = value.invokeAll(taskToExecute);
                System.out.println(new Date());
            } catch (InterruptedException e) {
                e.printStackTrace();
            } finally {
                // vamos eliminando los subprocesos, es IMPORTANTE hacer esto
                value.shutdown();
            }
        });
        System.out.println("--------------------- TERMINADO -----------------------");
    }
}
