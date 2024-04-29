# Creación de Hilos
Puedes crear hilos en Java utilizando la clase `Thread` o implementando la interfaz `Runnable`.

```java
// Creación mediante la clase Thread
Thread miHilo = new MiHilo();

// Creación mediante la interfaz Runnable
Runnable miRunnable = new MiRunnable();
Thread hiloRunnable = new Thread(miRunnable);
```

# Implementación de Runnable
Implementar la interfaz `Runnable` te permite separar la lógica del hilo de la clase `Thread`.

```java
class MiRunnable implements Runnable {
    public void run() {
        // Código del hilo
    }
}
```

# Método `run()`
El método `run()` contiene el código que se ejecutará en el hilo. Debes implementar la lógica de tu tarea en este método.

```java
class MiHilo extends Thread {
    public void run() {
        for (int i = 0; i < 5; i++) {
            System.out.println("Hilo: " + i);
        }
    }
}
```

# Iniciar un Hilo
Utiliza el método `start()` para iniciar un hilo. Esto llama automáticamente al método `run()`.

```java
miHilo.start();
hiloRunnable.start();
```

# Sincronización
Si múltiples hilos acceden y modifican los mismos recursos compartidos, puede haber problemas de concurrencia. Utiliza mecanismos de sincronización como `synchronized` y `Locks` para evitar condiciones de carrera y problemas de consistencia.

```java
class Contador {
    private int valor = 0;

    public synchronized void incrementar() {
        valor++;
    }

    public int getValor() {
        return valor;
    }
}
```

# Thread Pooling
En lugar de crear un nuevo hilo para cada tarea, es más eficiente utilizar un "pool" de hilos predefinidos que se reutilizan para diferentes tareas. Esto se puede lograr utilizando las clases `ExecutorService` y `ThreadPoolExecutor`.

```java
ExecutorService pool = Executors.newFixedThreadPool(5);
for (int i = 0; i < 10; i++) {
    pool.execute(new MiRunnable());
}
pool.shutdown();
```

# Manejo de Excepciones
Debes manejar las excepciones dentro del método `run()` ya que las excepciones lanzadas en hilos no son manejadas por el hilo principal.

```java
class MiHiloConExcepcion extends Thread {
    public void run() {
        try {
            // Código que puede lanzar excepciones
        } catch (Exception e) {
            System.err.println("Excepción en el hilo: " + e.getMessage());
        }
    }
}
```
