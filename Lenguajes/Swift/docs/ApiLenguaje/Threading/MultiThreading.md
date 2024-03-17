El multithreading en Swift se refiere a la capacidad de ejecutar múltiples hilos de ejecución (threads) de forma simultánea en una aplicación. Esto es especialmente útil para realizar tareas que pueden llevar tiempo de procesamiento, como descargar archivos, realizar operaciones intensivas en CPU o realizar peticiones de red, sin bloquear la interfaz de usuario y manteniendo la capacidad de respuesta de la aplicación.

# Grand Central Dispatch (GCD)
Es un framework que proporciona una forma sencilla de trabajar con hilos y ejecutar tareas concurrentes en Swift. Utiliza una cola de tareas para manejar la planificación y ejecución de los hilos.

Ejemplo:

```swift
DispatchQueue.global().async {
    // Realizar una tarea intensiva en CPU o una petición de red
    print("Tarea en segundo plano")
    
    DispatchQueue.main.async {
        // Actualizar la interfaz de usuario con los resultados de la tarea
        print("Tarea completada, actualizando interfaz de usuario")
    }
}
```

En este ejemplo, hemos utilizado GCD para realizar una tarea en segundo plano utilizando la cola global (`DispatchQueue.global().async`). Luego, hemos utilizado la cola principal (`DispatchQueue.main.async`) para actualizar la interfaz de usuario con los resultados de la tarea. Esto asegura que la interfaz de usuario se actualice de forma segura en el hilo principal.

# Operaciones en Cola (OperationQueue)
Es una API de más alto nivel que se basa en GCD y proporciona una interfaz orientada a objetos para trabajar con operaciones concurrentes. Permite establecer dependencias entre operaciones y controlar mejor la prioridad y la concurrencia.

Ejemplo:

```swift
let operationQueue = OperationQueue()

operationQueue.addOperation {
    // Realizar una tarea intensiva en CPU o una petición de red
    print("Tarea en segundo plano")
    
    OperationQueue.main.addOperation {
        // Actualizar la interfaz de usuario con los resultados de la tarea
        print("Tarea completada, actualizando interfaz de usuario")
    }
}
```

En este ejemplo, hemos utilizado `OperationQueue` para realizar una tarea en segundo plano utilizando la operación `addOperation`. Luego, hemos utilizado `OperationQueue.main.addOperation` para actualizar la interfaz de usuario con los resultados de la tarea.
