# Definir el Protocolo del Delegado:
Primero, necesitas definir un protocolo que describa las funciones que el delegado debe implementar.

```swift
protocol TareaDelegate: AnyObject {
    func tareaTerminada(resultado: String)
}
```

En este ejemplo, hemos definido un protocolo `TareaDelegate` con una función `tareaTerminada(resultado:)`. El protocolo es declarado con `AnyObject` para que solo las clases puedan ser delegados, evitando problemas de referencia circular.

# Crear el Objeto Delegado:
A continuación, creas el objeto delegador que utilizará el protocolo del delegado.

```swift
class Tarea {
    weak var delegate: TareaDelegate?

    func realizarTarea() {
        // Simulación de una tarea que toma tiempo
        print("Realizando la tarea...")
        // Supongamos que la tarea tomó 2 segundos en completarse
        DispatchQueue.main.asyncAfter(deadline: .now() + 2) {
            self.delegate?.tareaTerminada(resultado: "Tarea completada")
        }
    }
}
```

En este ejemplo, hemos creado una clase `Tarea` que tiene una variable `delegate` del tipo `TareaDelegate`. Cuando la tarea esté terminada, llamará a la función `tareaTerminada(resultado:)` del delegado.

# Implementar el Delegado:
Finalmente, implementas el delegado en otra clase.

```swift
class ViewController: UIViewController, TareaDelegate {
    let tarea = Tarea()

    override func viewDidLoad() {
        super.viewDidLoad()
        tarea.delegate = self
        tarea.realizarTarea()
    }

    func tareaTerminada(resultado: String) {
        print("El resultado de la tarea es: \(resultado)")
    }
}
```

En este ejemplo, hemos implementado el delegado en la clase `ViewController`. Hemos creado una instancia de `Tarea`, asignado el delegado a `self` (es decir, a la instancia de `ViewController`) y llamado a `realizarTarea()`. Cuando la tarea está terminada, la función `tareaTerminada(resultado:)` se invoca y se muestra el resultado.
