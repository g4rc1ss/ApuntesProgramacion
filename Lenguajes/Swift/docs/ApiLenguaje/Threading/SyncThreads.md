# Semáforos
Un semáforo es un mecanismo de sincronización que permite limitar el acceso a un recurso compartido utilizando contadores. Puedes usar semáforos para garantizar que solo un hilo pueda acceder al recurso compartido a la vez.

Ejemplo:

```swift
import Foundation

let semaphore = DispatchSemaphore(value: 1)

DispatchQueue.global().async {
    semaphore.wait()
    // Acceso al recurso compartido de forma segura
    print("Hilo 1 accediendo al recurso compartido")
    semaphore.signal()
}

DispatchQueue.global().async {
    semaphore.wait()
    // Acceso al recurso compartido de forma segura
    print("Hilo 2 accediendo al recurso compartido")
    semaphore.signal()
}
```

En este ejemplo, hemos utilizado un semáforo con un valor de 1 (`DispatchSemaphore(value: 1)`) para limitar el acceso al recurso compartido a un solo hilo a la vez. El primer hilo accede al recurso, y cuando finaliza, señala el semáforo (`semaphore.signal()`), permitiendo que el segundo hilo acceda al recurso de manera segura.

# Barreras:

Una barrera es un mecanismo que se utiliza en `DispatchQueue` para asegurar que todas las tareas previas a la barrera se completen antes de que comience la tarea de la barrera. Esto es útil para garantizar que todas las operaciones previas se hayan realizado antes de continuar con una operación crítica.

Ejemplo:

```swift
let concurrentQueue = DispatchQueue(label: "com.example.concurrentQueue", attributes: .concurrent)

concurrentQueue.async {
    // Tarea 1
}

concurrentQueue.async {
    // Tarea 2
}

concurrentQueue.async(flags: .barrier) {
    // Tarea de barrera (se ejecutará después de que terminen las tareas 1 y 2)
}

concurrentQueue.async {
    // Tarea 3 (se ejecutará después de que termine la tarea de barrera)
}
```

En este ejemplo, hemos utilizado una barrera (`concurrentQueue.async(flags: .barrier)`) para asegurar que la tarea 3 se ejecute después de que se completen las tareas 1 y 2, pero antes de que comience cualquier otra tarea agregada a la cola.

# Hilos con Locks (Bloqueos):

Otra forma de realizar sincronización de hilos es utilizando locks, como `NSLock` o `NSRecursiveLock`. Un lock permite que solo un hilo pueda acceder al recurso compartido a la vez. Puedes utilizar locks cuando necesites un control más fino sobre la sincronización de hilos.

Ejemplo:

```swift
import Foundation

let lock = NSLock()

DispatchQueue.global().async {
    lock.lock()
    // Acceso al recurso compartido de forma segura
    print("Hilo 1 accediendo al recurso compartido")
    lock.unlock()
}

DispatchQueue.global().async {
    lock.lock()
    // Acceso al recurso compartido de forma segura
    print("Hilo 2 accediendo al recurso compartido")
    lock.unlock()
}
```

En este ejemplo, hemos utilizado un `NSLock` para garantizar que solo un hilo pueda acceder al recurso compartido a la vez. Cuando un hilo adquiere el lock (`lock.lock()`), se bloquea hasta que el otro hilo lo libera (`lock.unlock()`).
