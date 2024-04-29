# Programación Asíncrona con Hilos
Utilizar hilos es una forma común de lograr asincronía en Java. Permite ejecutar múltiples tareas en paralelo.

```java
class TareaAsincrona extends Thread {
    public void run() {
        // Tarea que se ejecuta en segundo plano
    }
}

public class Asincronia {
    public static void main(String[] args) {
        TareaAsincrona tarea = new TareaAsincrona();
        tarea.start();

        // Tarea principal
        System.out.println("Tarea principal");
    }
}
```

# API CompletableFuture
La API CompletableFuture introducida en Java 8 simplifica la programación asíncrona y ofrece una forma más elegante de trabajar con resultados futuros.

```java
import java.util.concurrent.CompletableFuture;

public class AsincroniaCompletableFuture {
    public static void main(String[] args) {
        CompletableFuture<Integer> future = CompletableFuture.supplyAsync(() -> {
            // Tarea asincrónica que retorna un valor
            return 42;
        });

        // Tarea principal
        System.out.println("Tarea principal");

        // Obtener el resultado cuando esté disponible
        future.thenAccept(result -> {
            System.out.println("Resultado: " + result);
        });
    }
}
```

# Tareas en Paralelo
Puedes ejecutar múltiples tareas en paralelo utilizando `CompletableFuture.allOf()`.

```java
CompletableFuture<Integer> tarea1 = CompletableFuture.supplyAsync(() -> 10);
CompletableFuture<Integer> tarea2 = CompletableFuture.supplyAsync(() -> 20);

CompletableFuture<Void> todasLasTareas = CompletableFuture.allOf(tarea1, tarea2);
todasLasTareas.thenRun(() -> {
    int resultado1 = tarea1.join();
    int resultado2 = tarea2.join();
    System.out.println("Suma: " + (resultado1 + resultado2));
});
```

# Manejo de Excepciones
Puedes manejar excepciones en tareas asíncronas utilizando `exceptionally()`.

```java
CompletableFuture<Integer> future = CompletableFuture.supplyAsync(() -> {
    // Tarea que puede lanzar una excepción
    throw new RuntimeException("Algo salió mal");
});

future.exceptionally(ex -> {
    System.err.println("Excepción: " + ex.getMessage());
    return 0;
});
```

# Combinar Tareas
Puedes combinar el resultado de múltiples tareas utilizando métodos como `thenCombine()`.

```java
CompletableFuture<Integer> tarea1 = CompletableFuture.supplyAsync(() -> 10);
CompletableFuture<Integer> tarea2 = CompletableFuture.supplyAsync(() -> 20);

CompletableFuture<Integer> sumaTareas = tarea1.thenCombine(tarea2, (resultado1, resultado2) -> resultado1 + resultado2);
```
